using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Helpers;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using API.DBAccess.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using API.DBAccess.Entities;

namespace API.Controllers
{
    //[Route("user-agreements")]  
    public class UserAgreementsController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<UserAgreementsController> logger;

        public UserAgreementsController(IUnitOfWork unitOfWork, IMapper mapper
        , ILogger<UserAgreementsController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet("get-user-agreements")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserAgreementDto>>> GetUserAgreements(int? userId=null)
        {
            if(userId==null)
                userId=User.GetUserId();
            //get all agreements for which the decision was made
            var userAgreementsDto = await unitOfWork.UserAgreementRepository
            .GetUserAgreementsAsync(userId.Value,obligatory:false);
            var agreementIds=userAgreementsDto.Select(x=>x.AgreementId).ToList();
            //get all agreements list
            var agreements=await unitOfWork.AgreementRepository.GetAgreementsAsync(obligatory:false);
            var agreementsDto = mapper.Map<List<UserAgreementDto>>(agreements);
            //get list of agreements for which the decision wasn't made and add to the user agreements list
            agreementsDto=agreementsDto.Where(x=>!agreementIds.Contains(x.AgreementId)).ToList();
            userAgreementsDto.AddRange(agreementsDto);
            userAgreementsDto =userAgreementsDto.OrderBy(x=>x.AgreementId).ToList();

            return Ok(userAgreementsDto);
        }

        [HttpPost("update-user-agreements")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserAgreementDto>>> UpdateUserAgreements(UserAgreementDto[] userAgreementDto)
        {
            if(userAgreementDto==null)
                return BadRequest();

            var userId=User.GetUserId();
            var userAgreementsToUpdate = userAgreementDto.Where(x=>x.Id > 0).ToList();
            var userAgreementsToInsert = userAgreementDto.Where(x=>x.Id == 0).ToList();
            //return BadRequest();
            // //get all agreements for which the decision was made
            var userAgreements = await unitOfWork.UserAgreementRepository
            .GetUserAgreementsAsync(userId,obligatory:false);
            //update only agreements which changed values
            userAgreementsToUpdate.ForEach(uAgreement=>{
                if(userAgreements.FirstOrDefault(x=>x.Id==uAgreement.Id).Value!=uAgreement.Value){
                    unitOfWork.UserAgreementRepository.Update(uAgreement.Id,uAgreement.Value);
                }
            });
            //add new user agreements
            userAgreementsToInsert.ForEach(uAgreement=>{
                unitOfWork.UserAgreementRepository
                .AddUserAgreement(new UserAgreement(){AppUserId=userId,AgreementId=uAgreement.AgreementId,Value=uAgreement.Value});
            });
            var savingResult = await unitOfWork.Complete();

            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");
            
            var currentUserAgreements = await unitOfWork.UserAgreementRepository
            .GetUserAgreementsAsync(userId,obligatory:false);
            return Ok(currentUserAgreements);
        }
    }
}
