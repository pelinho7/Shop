using System.IO;
using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using API.DTOs;
using API.Extensions;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using API.DBAccess.Data;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ITokenService tokenService;
        private readonly IEmailService emailService;
        private readonly IMapper mapper;
        private readonly ILogger<AccountController> logger;
        private readonly RoleManager<AppUser> roleManager;

        public AccountController(IUnitOfWork unitOfWork, SignInManager<AppUser> signInManager
            , UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor
            , ITokenService tokenService, IEmailService emailService, IMapper mapper
            , ILogger<AccountController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
            this.tokenService = tokenService;
            this.emailService = emailService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [NonAction]
        private async Task<AppUser> getUserByLoginOrEmail(string loginEmail)
        {
            var user = await unitOfWork.UserRepository.GetUserByUsernameAsync(loginEmail);

            if (user == null)
            {
                user = await unitOfWork.UserRepository.GetUserByEmailAsync(loginEmail);
            }

            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            if (loginDto == null)
                return BadRequest();

            var user = await getUserByLoginOrEmail(loginDto.Login);//await unitOfWork.UserRepository.GetUserByUsernameAsync(loginDto.Login);

            if (user == null)
                return Unauthorized($"Invalid user");

            if (!user.EmailConfirmed)
            {
                var roles = await userManager.GetRolesAsync(user);
                if (!roles.Contains(AppRoleEnum.Admin.ToString()))
                {
                    return Unauthorized($"Invalid user");
                }
            }

            var singInResult = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!singInResult.Succeeded) return Unauthorized();

            return new UserDto()
            {
                Username = user.UserName,
                Token = await tokenService.CreateToken(user)
            };
        }

        [NonAction]
        private async Task<(bool, string)> sendAccountActivationEmailAsync(Uri uri, AppUser user, IEmailService emailService)
        {
            string emailConfirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
            string host = httpContextAccessor.HttpContext.Request.Host.Value;
            StringWriter emailBody = new StringWriter();
            XmlTextWriter xml = new XmlTextWriter(emailBody);
            xml.Formatting = Formatting.Indented;
            xml.WriteElementString("h5", String.Format("Dear {0}", user.UserName));
            xml.WriteString($"Below is link available to confirm your email. Link will be active for one day.");
            xml.WriteStartElement("br");
            xml.WriteEndElement();
            xml.WriteElementString("p", $"{uri}account/email-confirmation?id={user.Id}&token={Uri.EscapeDataString(emailConfirmationToken)}");
            xml.Flush();

            (bool sendEmailResult, string message) = await emailService.SendEmailAsync(user.Email, "Account activation link", emailBody.ToString().ToString());

            return new(sendEmailResult, message);
        }

        [NonAction]
        private async Task<(bool, string)> sendResetPasswordEmailAsync(Uri uri, AppUser user, IEmailService emailService)
        {
            string resetPasswordToken = await userManager.GeneratePasswordResetTokenAsync(user);
            string host = httpContextAccessor.HttpContext.Request.Host.Value;
            StringWriter emailBody = new StringWriter();
            XmlTextWriter xml = new XmlTextWriter(emailBody);
            xml.Formatting = Formatting.Indented;
            xml.WriteElementString("h5", String.Format("Dear {0}", user.UserName));
            xml.WriteString($"Below is link available to reset your password to your account. Link will be active for one day..");
            xml.WriteStartElement("br");
            xml.WriteEndElement();
            xml.WriteElementString("p", $"{uri}account/new-password?id={user.Id}&token={Uri.EscapeDataString(resetPasswordToken)}");
            xml.Flush();

            (bool sendEmailResult, string message) = await emailService.SendEmailAsync(user.Email, "Account activation link", emailBody.ToString().ToString());

            return new(sendEmailResult, message);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (registerDto == null)
                return BadRequest();

            var user = mapper.Map<AppUser>(registerDto);

            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            //record of user history
            unitOfWork.UserHistoryRepository.AddUserHistory(user);

            var roleResult = await userManager.AddToRoleAsync(user, AppRoleEnum.User.ToString());

            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            registerDto.Agreements.ForEach(agreementDto =>
            {
                var userAgreement = mapper.Map<AgreementDto, UserAgreement>(agreementDto);
                userAgreement.AppUserId = user.Id;
                unitOfWork.UserAgreementRepository.AddUserAgreement(userAgreement);
                unitOfWork.UserAgreementHistoryRepository.AddUserAgreementHistory(userAgreement);
            });

            var savingResult = await unitOfWork.Complete();
            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");

            //get uri of incoming request
            Uri uri = Request.GetTypedHeaders().Referer;
            (bool emailResult, string message) = await sendAccountActivationEmailAsync(uri, user, emailService);

            return new UserDto()
            {
                Username = user.UserName
            };
        }

        [HttpPost("resend-verification-email")]
        public async Task<ActionResult<UserDto>> ResendVerificationEmail(LoginDto loginDto)
        {
            if (loginDto == null)
                return BadRequest();

            var user = await unitOfWork.UserRepository.GetUserByUsernameAsync(loginDto.Login);

            if (user == null)
                return Unauthorized($"Invalid user");

            var singInResult = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!singInResult.Succeeded) return Unauthorized();

            //get uri of incoming request
            Uri uri = Request.GetTypedHeaders().Referer;
            (bool emailResult, string message) = await sendAccountActivationEmailAsync(uri, user, emailService);

            if (emailResult)
            {
                return Ok();
            }
            else
            {
                return BadRequest(message);
            }
        }

        [HttpGet("reset-password")]
        public async Task<ActionResult> ResetPassword(string login)
        {
            if (login == null)
                return BadRequest();

            var user = await getUserByLoginOrEmail(login);
            if (user == null)
            {
                return Unauthorized($"Invalid user");
            }

            //get uri of incoming request
            Uri uri = Request.GetTypedHeaders().Referer;
            (bool emailResult, string message) = await sendResetPasswordEmailAsync(uri, user, emailService);

            if (emailResult)
            {
                return Ok();
            }
            else
            {
                return BadRequest(message);
            }
        }

        [HttpGet("check-email-not-taken")]
        public async Task<ActionResult<bool>> CheckEmailNotTaken(string email)
        {
            if (string.IsNullOrEmpty(email)) return true;

            var userByEmail = await unitOfWork.UserRepository.GetUserByEmailAsync(email);
            if (userByEmail == null) return true;

            var currentUserId = User.GetUserId();
            if (userByEmail.Id == currentUserId) return true;

            return false;
        }

        [Authorize]
        [HttpGet("check-login-not-taken")]
        public async Task<ActionResult<bool>> CheckLoginNotTaken(string login)
        {
            if (string.IsNullOrEmpty(login)) return true;

            var currentUserId = User.GetUserId();
            var userByLogin = await unitOfWork.UserRepository.GetUserByUsernameAsync(login);
            var userByEmail = await unitOfWork.UserRepository.GetUserByEmailAsync(login);
            //filter current user
            if (userByLogin != null && userByLogin.Id == currentUserId)
            {
                userByLogin = null;
            }
            if (userByEmail != null && userByEmail.Id == currentUserId)
            {
                userByEmail = null;
            }
            if (userByLogin == null && userByEmail == null) return true;

            return false;
        }

        [HttpGet("email-confirmation")]
        public async Task<ActionResult<UserDto>> EmailConfirmation(string id, string token)
        {

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(token))
            {
                return BadRequest();
            }

            token = Uri.UnescapeDataString(token);
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return Unauthorized($"Invalid user");
            }

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {

                return new UserDto()
                {
                    Username = user.UserName,
                    Token = await tokenService.CreateToken(user)
                };
            }

            return BadRequest();
        }

        [HttpPost("new-password")]
        public async Task<ActionResult> NewPassword(NewPasswordDto newPasswordDto)
        {

            if (newPasswordDto == null || string.IsNullOrEmpty(newPasswordDto.ResetPasswordToken)
            || newPasswordDto.UserId < 1)
            {
                return BadRequest();
            }

            newPasswordDto.ResetPasswordToken = Uri.UnescapeDataString(newPasswordDto.ResetPasswordToken);
            var user = await unitOfWork.UserRepository.GetUserByIdAsync(newPasswordDto.UserId);
            if (user == null)
                return Unauthorized($"Invalid user");

            var resetPasswordResult = await userManager.ResetPasswordAsync(user
                , newPasswordDto.ResetPasswordToken, newPasswordDto.NewPassword);

            if (!resetPasswordResult.Succeeded)
            {
                resetPasswordResult.Errors.ToList().ForEach(x => ModelState.AddModelError("", $"{x.Description}"));
                return BadRequest(resetPasswordResult?.Errors.FirstOrDefault().Description);
            }
            else
                return Ok();
        }

        #region account data
        [Authorize]
        [HttpGet("{data}")]
        public async Task<ActionResult<AccountDataDto>> AccountData()
        {
            var currentUserId = User.GetUserId();
            var user = await unitOfWork.UserRepository.GetUserByIdAsync(currentUserId);
            if (user == null)
                return Unauthorized($"Invalid user");

            return mapper.Map<AccountDataDto>(user);
        }

        [Authorize]
        [HttpPost("{data}")]
        public async Task<ActionResult<UserDto>> AccountData(AccountDataDto accountDataDto)
        {
            if (accountDataDto == null) BadRequest();
            var currentUserId = User.GetUserId();
            var user = await unitOfWork.UserRepository.GetUserByIdAsync(currentUserId);
            if (user == null)
                return Unauthorized($"Invalid user");

            var dto = mapper.Map<AccountDataDto>(user);

            if (accountDataDto.Equals(dto))
            {
                return new UserDto() { Username = accountDataDto.Username };
            }

            user.UserName = accountDataDto.Username;
            user.Email = accountDataDto.Email;
            user.FirstName = accountDataDto.FirstName;
            user.LastName = accountDataDto.LastName;
            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");

            unitOfWork.UserHistoryRepository.AddUserHistory(user);
            var savingResult = await unitOfWork.Complete();
            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");

            return new UserDto() { Username = accountDataDto.Username };
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            if(changePasswordDto == null)
                return BadRequest();

            var currentUserId = User.GetUserId();
            var user = await unitOfWork.UserRepository.GetUserByIdAsync(currentUserId);
            if (user == null)
                return Unauthorized($"Invalid user");

            var checkPasswordResult = await userManager.CheckPasswordAsync(user,changePasswordDto.ActualPassword);
            if(!checkPasswordResult)
                return Unauthorized($"Incorrect password");
            
            var changePasswordResult=await userManager.ChangePasswordAsync(user,changePasswordDto.ActualPassword,changePasswordDto.NewPassword);
            if(!changePasswordResult.Succeeded){
                return BadRequest(changePasswordResult.Errors.Count()>0?changePasswordResult.Errors.First().Description:"");
            }

            unitOfWork.UserHistoryRepository.AddUserHistory(user);
            await unitOfWork.Complete();

            return Ok();
        }
        #endregion
    }
}