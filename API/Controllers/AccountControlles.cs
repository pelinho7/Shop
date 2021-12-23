using System.Threading.Tasks;
using API.DBAccess.Entities;
using API.DBAccess.Interfaces;
using API.DTOs;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ITokenService tokenService;

        public AccountController(IUnitOfWork unitOfWork,SignInManager<AppUser> signInManager
            ,ITokenService tokenService)
        {
            this.unitOfWork = unitOfWork;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        //[HttpGet]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            if(loginDto==null)
                return BadRequest();

            var user = await unitOfWork.UserRepository.GetUserByUsernameAsync(loginDto.Login);

            if(user == null)
                return Unauthorized($"Invalid user");
            
            var singInResult = await signInManager.CheckPasswordSignInAsync(user,loginDto.Password,false);

            if(!singInResult.Succeeded) return Unauthorized();

            return new UserDto(){
                Username=user.UserName,
                Token=await tokenService.CreateToken(user)
            } ;
        }
    }
}