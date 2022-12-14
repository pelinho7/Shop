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
using API.Services.Interfaces;
using API.DBAccess;
using Microsoft.AspNetCore.Http;
using API.DBAccess.Entities;

namespace API.Controllers
{
    public class OpinionsController : BaseApiController
    {
        private readonly ILogger<OpinionsController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OpinionsController(IUnitOfWork unitOfWork, IMapper mapper
        , ILogger<OpinionsController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OpinionDto>>> GetOpinions([FromQuery]GetOpinionsParamDto opinionsParamDto)
        {
            if(opinionsParamDto == null) return BadRequest();
            if(opinionsParamDto.ProductId <= 0) return BadRequest();

            var pagination=new Pagination();
            if(opinionsParamDto.Page.HasValue){
                pagination.Page=opinionsParamDto.Page.Value;
            }
            if(opinionsParamDto.ItemsPerPage.HasValue){
                pagination.ItemsPerPage=opinionsParamDto.ItemsPerPage.Value;
            }
           
            var opinions = await unitOfWork.OpinionRepository.GetOpinions(opinionsParamDto.ProductId
            , (OpinionSortingTypeEnum)opinionsParamDto.SortingType,pagination);
            var opinionDtos=opinions.Select(x=> mapper.Map<OpinionDto>(x)).ToList();
            //logger.LogError(JsonSerializer.Serialize(opinionDtos));
            Response.AddHeader(new Pagination(){Page=opinions.CurrentPage,TotalPages=opinions.TotalPages},"Pagination");

            return Ok(opinionDtos);
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<OpinionDto>> InsertOpinion(OpinionDto opinionDto)
        {
            if (opinionDto == null)
                return BadRequest();

            var userId = User.GetUserId();

            if (opinionDto.ProductId == 0) return BadRequest();

            var opinion = mapper.Map<Opinion>(opinionDto);
            opinion.AppUserId=userId;
            unitOfWork.OpinionRepository.AddOpinion(opinion);
           
            bool savingResult;
            savingResult = await unitOfWork.Complete();
            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");

            opinionDto = mapper.Map<OpinionDto>(opinion);
            return Ok(opinionDto);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<OpinionDto>> UpdateOpinion(OpinionDto opinionDto)
        {
            if (opinionDto == null)
                return BadRequest();

            var userId = User.GetUserId();

            if (opinionDto.ProductId == 0) return BadRequest();

            var opinion = mapper.Map<Opinion>(opinionDto);
            
            var updatedOpinion  = await unitOfWork.OpinionRepository.UpdateOpinion(opinion);
           
            bool savingResult;
            savingResult = await unitOfWork.Complete();
            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");

            opinionDto = mapper.Map<OpinionDto>(updatedOpinion);
            opinionDto.UserId=userId;
            opinionDto.UserName=User.GetUserName();
            return Ok(opinionDto);
        }

        [HttpDelete("{opinionId:int}")]
        [Authorize]
        public async Task<ActionResult> Delete(int opinionId)
        {
            if (opinionId <= 0)
                return BadRequest();


            unitOfWork.OpinionRepository.DeleteOpinion(opinionId);
            var savingResult = await unitOfWork.Complete();

            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Deleting incompleted");

            return Ok();
        }
    }
}
