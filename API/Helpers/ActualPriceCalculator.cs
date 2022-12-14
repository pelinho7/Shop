using System;
using System.Collections.Generic;
using System.Linq;
using API.DBAccess.Entities;
using API.DTOs;
using AutoMapper;

namespace API.Helpers
{
    public class ActualPriceCalculator
    {
        // public ActualPriceCalculator(IMapper mapper)
        // {
            
        // }
        public static ActualPriceDto Calculate(List<DiscountDto> discountsDtos, double basePrice)
        {
            var discount = discountsDtos?.FirstOrDefault();
            if (discount == null) return null;
            else
            {
                double discountPrice;
                if (discount.Type == 0)
                {
                    discountPrice = (100 - discount.Value) * basePrice/100;
                }
                else
                {
                    discountPrice = basePrice - discount.Value;
                }
                return new ActualPriceDto() { DiscountPrice = Math.Round(discountPrice, 2), DiscountStartDate = discount.StartDate, DiscountEndDate = discount.EndDate };
            }
        }

        // public ActualPriceDto Calculate(List<Discount> discounts, double basePrice){
        //     return Calculate()
        // }
    }
}