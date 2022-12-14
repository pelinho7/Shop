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
    public class OpinionLikesController : BaseApiController
    {
        private readonly ILogger<OpinionLikesController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OpinionLikesController(IUnitOfWork unitOfWork, IMapper mapper
        , ILogger<OpinionLikesController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult> InsertLike(OpinionLikeDto opinionLikeDto)
        {
            if (opinionLikeDto == null)
                return BadRequest();

            var userId = User.GetUserId();
            opinionLikeDto.UserId = userId;
            
            var opinionLike = mapper.Map<OpinionLike>(opinionLikeDto);
            unitOfWork.OpinionLikeRepository.AddLikeOpinion(opinionLike);
           
            bool savingResult;
            savingResult = await unitOfWork.Complete();
            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");

            opinionLikeDto = mapper.Map<OpinionLikeDto>(opinionLike);
            return Ok(opinionLikeDto);
        }


        [HttpDelete("{opinionLikeId:int}")]
        [Authorize]
        public async Task<ActionResult> Delete(int opinionLikeId)
        {
            if (opinionLikeId <= 0)
                return BadRequest();


            unitOfWork.OpinionLikeRepository.DeleteOpinionLike(opinionLikeId);
            var savingResult = await unitOfWork.Complete();

            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Deleting incompleted");

            return Ok();
        }
    }
}
