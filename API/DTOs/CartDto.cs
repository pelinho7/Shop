using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class CartDto
    {
        public Guid Id { get; set; }
        public List<CartLineDto> CartLines { get; set; }=new List<CartLineDto>();
    }
}