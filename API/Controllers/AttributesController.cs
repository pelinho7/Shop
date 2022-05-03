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

namespace API.Controllers
{
    public class AttributesController : BaseApiController
    {
        private readonly ILogger<AttributesController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ICreateHistoryService createHistoryService;

        public AttributesController(IUnitOfWork unitOfWork, IMapper mapper
        , ILogger<AttributesController> logger, ICreateHistoryService createHistoryService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
            this.createHistoryService = createHistoryService;
        }


        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttributeDto>>> GetAttributes([FromQuery]GetAttributesParamDto paramsDto)
        {
            var pagination=new Pagination();
            if(paramsDto.Page.HasValue){
                pagination.Page=paramsDto.Page.Value;
            }
            if(paramsDto.ItemsPerPage.HasValue){
                pagination.ItemsPerPage=paramsDto.ItemsPerPage.Value;
            }
            var attributes = await unitOfWork.AttributeRepository.GetAttributes(paramsDto.Code,paramsDto.Type,pagination);
            //Response.AddHeader(new Pagination(){Page=paramsDto.Page.HasValue?paramsDto.Page.Value:2},"Pagination");
            Response.AddHeader(new Pagination(){Page=attributes.CurrentPage,TotalPages=attributes.TotalPages},"Pagination");

            return Ok(attributes);
        }

        [HttpPost("upsert-attribute")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<AttributeDto>> UpsertAttribute(AttributeDto attributeDto)
        {
            if(attributeDto==null)
                return BadRequest();

            var userId=User.GetUserId();
            var attribute = mapper.Map<DBAccess.Entities.Attribute>(attributeDto);
            bool savingResult;
            if(attribute.Id == 0){
                unitOfWork.AttributeRepository.AddAttribute(attribute);
                savingResult = await unitOfWork.Complete();
                if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");

                unitOfWork.AttributeHistoryRepository.AddAttributeHistory(attribute);
            }
            else{
                unitOfWork.AttributeRepository.UpdateAttribute(attribute);
            }
            savingResult = await unitOfWork.Complete();

            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");

            return Ok(mapper.Map<AttributeDto>(attribute));
        }

        [HttpDelete("delete-attribute/{attributeId:int}")]
        [Authorize]
        public async Task<ActionResult> DeleteAttribute(int attributeId)
        {
            if(attributeId<=0)
                return BadRequest();

            var userId=User.GetUserId();
            // var attribute = await unitOfWork.AttributeRepository.GetAttributeById(attributeId);
            // if(attribute == null)return NotFound("Attribute not found");

            unitOfWork.AttributeRepository.DeleteAttribute(attributeId);
            var savingResult = await unitOfWork.Complete();

            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Deleting incompleted");

            return Ok();
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("check-code-not-taken")]
        public async Task<ActionResult<bool>> CheckCodeNotTaken(string code)
        {
            if (string.IsNullOrEmpty(code)) return true;

            var attribute = await unitOfWork.AttributeRepository.GetAttributeByCode(code);
            if (attribute != null)
            {
                return false;
            }

            return true;
        }

        [HttpGet("get-attribute-history")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<IEnumerable<HistoryDto>>> GetAttributeHistory(int id,int timezone,string location)
        {
            var attributeHistory = await unitOfWork.AttributeHistoryRepository.GetAttributeHistoryByIdAsync(id);
            var groupedAttributes=attributeHistory.GroupBy(x=>x.AttributeId).ToList();
            var historyList = createHistoryService.CreateHistory(groupedAttributes,timezone,location);

            return Ok(historyList);
        }
    }
}
