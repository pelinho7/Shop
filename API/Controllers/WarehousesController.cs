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
    public class WarehousesController : BaseApiController
    {
        private readonly ILogger<WarehousesController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ICreateHistoryService createHistoryService;

        public WarehousesController(IUnitOfWork unitOfWork, IMapper mapper
        , ILogger<WarehousesController> logger, ICreateHistoryService createHistoryService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
            this.createHistoryService = createHistoryService;
        }


        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseDto>>> GetWarehouses([FromQuery]GetWarehousesParamDto paramsDto)
        {
            var pagination=new Pagination();
            if(paramsDto.Page.HasValue){
                pagination.Page=paramsDto.Page.Value;
            }
            if(paramsDto.ItemsPerPage.HasValue){
                pagination.ItemsPerPage=paramsDto.ItemsPerPage.Value;
            }
            var warehouses = await unitOfWork.WarehouseRepository.GetWarehouses(paramsDto.Code,pagination);
            Response.AddHeader(new Pagination(){Page=warehouses.CurrentPage,TotalPages=warehouses.TotalPages},"Pagination");

            return Ok(warehouses);
        }

        // [Authorize(Roles ="Admin")]
        // [HttpGet("get-all-attributes")]
        // public async Task<ActionResult<IEnumerable<AttributeBasicDto>>> GetAllAttributes()
        // {
        //     var attributes = await unitOfWork.AttributeRepository.GetAllAttributes();
        //     return Ok(attributes);
        // }

        [HttpPost("upsert-warehouse")]
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<WarehouseDto>> UpsertWarehouse(WarehouseDto warehouseDto)
        {
            if(warehouseDto==null)
                return BadRequest();

            var userId=User.GetUserId();
            var warehouse = mapper.Map<DBAccess.Entities.Warehouse>(warehouseDto);
            bool savingResult;
            if(warehouse.Id == 0){
                unitOfWork.WarehouseRepository.AddWarehouse(warehouse);
            }
            else{
                unitOfWork.WarehouseRepository.UpdateWarehouse(warehouse);
            }
            savingResult = await unitOfWork.Complete();

            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");

            return Ok(mapper.Map<WarehouseDto>(warehouse));
        }

        [HttpDelete("delete-warehouse/{warehouseId:int}")]
        [Authorize]
        public async Task<ActionResult> DeleteWarehouse(int warehouseId)
        {
            if(warehouseId<=0)
                return BadRequest();

            var userId=User.GetUserId();

            unitOfWork.WarehouseRepository.DeleteWarehouse(warehouseId);
            var savingResult = await unitOfWork.Complete();

            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Deleting incompleted");

            return Ok();
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("check-code-not-taken")]
        public async Task<ActionResult<bool>> CheckCodeNotTaken(string code)
        {
            if (string.IsNullOrEmpty(code)) return true;

            var warehouse = await unitOfWork.WarehouseRepository.GetWarehouseByCode(code);
            if (warehouse != null)
            {
                return false;
            }

            return true;
        }
    }
}
