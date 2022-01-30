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
    public class ShippingAddressesController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<ShippingAddressesController> logger;

        public ShippingAddressesController(IUnitOfWork unitOfWork, IMapper mapper
        , ILogger<ShippingAddressesController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet("get-shipping-addresses")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ShippingAddressDto>>> GetShippingAddresses(int? userId=null)
        {
            if(userId==null)
                userId=User.GetUserId();
   
            var shippingAddresses = await unitOfWork.ShippingAddressRepository
                .GetUserShippingAddressesAsync(userId.Value);
            // List<ShippingAddressDto> a=new List<ShippingAddressDto>();
            // a.Add(new ShippingAddressDto(){Id=10});
            // a.Add(new ShippingAddressDto(){Id=11});
            return Ok(mapper.Map<List<ShippingAddressDto>>(shippingAddresses));
        }

        [HttpPost("upsert-shipping-address")]
        [Authorize]
        public async Task<ActionResult<ShippingAddressDto>> UpsertShippingAddress(ShippingAddressDto shippingAddresDto)
        {
            if(shippingAddresDto==null)
                return BadRequest();

            var userId=User.GetUserId();
            var shippingAddress = mapper.Map<ShippingAddress>(shippingAddresDto);
            shippingAddress.AppUserId=userId;
            bool savingResult;
            if(shippingAddress.Id == 0){
                unitOfWork.ShippingAddressRepository.AddShippingAddress(shippingAddress);
                savingResult = await unitOfWork.Complete();
                if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");

                unitOfWork.ShippingAddressHistoryRepository.AddShippingAddressHistory(shippingAddress);
            }
            else{
                //unitOfWork.ShippingAddressRepository.AddShippingAddress(shippingAddress);
            }
            savingResult = await unitOfWork.Complete();

            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");

            return Ok(mapper.Map<ShippingAddressDto>(shippingAddress));
        }

        [HttpDelete("delete-shipping-address/{addressId:int}")]
        [Authorize]
        public async Task<ActionResult> DeleteShippingAddress(int addressId)
        {
            if(addressId<=0)
                return BadRequest();

            var userId=User.GetUserId();
            var shippingAddress = await unitOfWork.ShippingAddressRepository.GetUserShippingAddressByIdAsync(addressId);
            if(shippingAddress == null)return NotFound("Address not found");
            if(shippingAddress.AppUserId != userId)return Unauthorized();

            unitOfWork.ShippingAddressRepository.DeleteShippingAddress(addressId);
            var savingResult = await unitOfWork.Complete();

            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Deleting incompleted");

            return Ok();
        }
    }
}
