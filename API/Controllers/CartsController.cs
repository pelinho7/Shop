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
    public class CartsController : BaseApiController
    {
        private readonly ILogger<CartsController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CartsController(IUnitOfWork unitOfWork, IMapper mapper
        , ILogger<CartsController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet("{id}")]
        //[HttpGet]
        public async Task<ActionResult<CartDto>> GetCart(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;
            Guid idGuid;
            if (!Guid.TryParse(id, out idGuid))
            {
                return BadRequest("Wrong cart ID");
            }
            var cart = await unitOfWork.CartRepository.GetCart(idGuid);
            var cartDto = mapper.Map<CartDto>(cart);

            return Ok(cartDto);
        }


        [HttpPost("add-to-cart")]
        public async Task<ActionResult<CartLineDto>> AddToCart(CartLineDto cartLineDto)
        {
            if (cartLineDto == null)
                return BadRequest();

            bool savingResult;
            using (var transaction = await unitOfWork.BeginTransaction())
            {
                try
                {
                    var productAmount = await unitOfWork.ProductAmountRepository.GetProductAmounts(cartLineDto.ProductId);
                    if (productAmount.Sum(x => x.Amount) < cartLineDto.Quantity)
                        return StatusCode(StatusCodes.Status403Forbidden, "Lack of quantity");

                    bool cartCreated = false;
                    Cart cart = null;
                    if (!string.IsNullOrEmpty(cartLineDto.CartId))
                    {
                        cart = await unitOfWork.CartRepository.GetCart(Guid.Parse(cartLineDto.CartId));
                        if (cart != null)
                        {
                            var actualCartLine = await unitOfWork.CartLineRepository.GetCartLine(cart.Id, cartLineDto.ProductId);
                            if (actualCartLine != null)
                            {
                                cartLineDto.Id = actualCartLine.Id;
                                cartLineDto.Quantity += actualCartLine.Quantity;
                            }
                        }
                    }

                    if (cart == null)
                    {
                        cart = new Cart();
                        unitOfWork.CartRepository.AddCart(cart);
                        savingResult = await unitOfWork.Complete();
                        if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");
                        cartLineDto.CartId = cart.Id.ToString();
                        cartCreated = true;
                    }

                    var cartLine = mapper.Map<CartLine>(cartLineDto);
                    if (cartLine.Id > 0)
                    {
                        unitOfWork.CartLineRepository.UpdateCartLine(cartLine);
                    }
                    else
                    {
                        unitOfWork.CartLineRepository.AddCartLine(cartLine);
                    }

                    if (!cartCreated)
                    {
                        unitOfWork.CartRepository.UpdateCart(cart);
                    }

                    savingResult = await unitOfWork.Complete();
                    if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");

                    transaction.Commit();
                    cartLine = await unitOfWork.CartLineRepository.GetCartLine(cartLine.Id);
                    cartLineDto = mapper.Map<CartLineDto>(cartLine);
                    return Ok(cartLineDto);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return StatusCode(StatusCodes.Status500InternalServerError, "Saving data incompleted");
                }
            }
        }


        [HttpDelete("delete-cartline/{id:int}")]
        public async Task<ActionResult> DeleteCartLine(int id)
        {
            if (id <= 0)
                return BadRequest();

            unitOfWork.CartLineRepository.DeleteCartLine(id);
            var savingResult = await unitOfWork.Complete();

            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Deleting incompleted");

            return Ok();
        }

        [HttpPatch("update-line-quantity")]
        public async Task<ActionResult<CartLineDto>> UpdateLineQuantity(CartLineDto cartLineDto)
        {
            if (cartLineDto == null)
                return BadRequest();

            var cartLine = mapper.Map<CartLine>(cartLineDto);
            unitOfWork.CartLineRepository.UpdateCartLineQuantity(cartLine);
            var savingResult = await unitOfWork.Complete();

            if (!savingResult) return StatusCode(StatusCodes.Status500InternalServerError, "Updating incompleted");

            return Ok(cartLineDto);
        }

        [HttpGet("prices/{id}")]
        public async Task<ActionResult<List<CartLineDto>>> Prices(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;
            Guid idGuid;
            if (!Guid.TryParse(id, out idGuid))
            {
                return BadRequest("Wrong cart ID");
            }

            var cartLines = await unitOfWork.CartRepository.GetCartPrices(idGuid);
            var cartLinesDtos = cartLines.Select(x=>mapper.Map<CartLineDto>(x))
            .Select(x=>new CartLineDto(){Id=x.Id,Price=x.Price,ActualPrice=x.ActualPrice});
            
            return Ok(cartLinesDtos);
        }
    }
}
