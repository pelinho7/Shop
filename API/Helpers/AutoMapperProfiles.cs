using System;
using System.Collections.Generic;
using System.Linq;
using API.DBAccess.Entities;
using API.DTOs;
using API.Extensions;
using API.Helpers.AutoMapper;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Agreement, AgreementDto>();
            CreateMap<AgreementDto, UserAgreement>()
            .ForMember(dest => dest.AgreementId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Checked));
            CreateMap<RegisterDto, AppUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            CreateMap<AppUser, AppUserHistory>()
            .ForSourceMember(x => x.Id, y => y.DoNotValidate())
            .ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(x => x.Id, opt => opt.MapFrom(src => 0));
            CreateMap<UserAgreement, UserAgreementHistory>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => 0));
            CreateMap<AppUser, AccountDataDto>();
            CreateMap<UserAgreement, UserAgreementDto>()
            .ForMember(dest => dest.Contents, opt => opt.MapFrom(src => src.Agreement.Contents));
            CreateMap<Agreement, UserAgreementDto>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.AgreementId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Contents, opt => opt.MapFrom(src => src.Contents));
            CreateMap<ShippingAddress, ShippingAddressDto>();
            CreateMap<ShippingAddressDto, ShippingAddress>();
            CreateMap<ShippingAddress, ShippingAddressHistory>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.ShippingAddressId, opt => opt.MapFrom(src => src.Id));
            CreateMap<AttributeDto, DBAccess.Entities.Attribute>();
            CreateMap<DBAccess.Entities.Attribute, AttributeDto>();
            CreateMap<DBAccess.Entities.Attribute, AttributeBasicDto>();
            CreateMap<DBAccess.Entities.Attribute, AttributeHistory>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.AttributeId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CategoryAttributeDto, CategoryAttribute>();

            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryHistory>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id));
            CreateMap<CategoryAttribute, CategoryAttributeHistory>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.CategoryAttributeId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CategoryAttribute, CategoryAttributeDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryTreeItemDto>();

            CreateMap<Photo, PhotoDto>();
            CreateMap<Discount, DiscountDto>();
            CreateMap<DiscountDto, Discount>();

            CreateMap<Product, ProductBasicDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductListItemDto>()
            .ForMember(dest => dest.MainPhotoUrl, opt => opt.MapFrom(src => (src.Photos == null || !src.Photos.Any()) ? null : src.Photos.OrderBy(x => x.Lp).FirstOrDefault().Url));
 
            CreateMap<Product, ProductFullDataDto>();

            CreateMap<CategoryAttribute, ProductAttributeOrderDto>();

            CreateMap<Product, UpsertProductDto>();
            CreateMap<UpsertProductDto, Product>()
            .ForMember(dest => dest.ProductAmounts, opt => opt.Ignore());
            //.ForMember(dest=>dest.Discounts, opt => opt.MapFrom(src => src.ProductDiscounts));            CreateMap<ProductDto,Product>();

            CreateMap<CategoryAttribute, ProductTextAttributeDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0));
            CreateMap<CategoryAttribute, ProductNumberAttributeDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.DecimalPlaces, opt => opt.MapFrom(src => src.Attribute != null ? src.Attribute.DecimalPlaces : 0));

            CreateMap<ProductNumberAttribute, ProductNumberAttributeDto>()
            .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Attribute == null? null:src.Attribute.Label));
            CreateMap<ProductTextAttribute, ProductTextAttributeDto>()
            .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Attribute == null? null:src.Attribute.Label));

            CreateMap<Warehouse, WarehouseDto>();
            CreateMap<WarehouseDto, Warehouse>();
            CreateMap<ProductAmount, ProductAmountDto>()
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Warehouse.Code))
            .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Warehouse.Label));
            CreateMap<ProductAmountDto, ProductAmount>();

            CreateMap<Warehouse, ProductAmountDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Label));



            CreateMap<Product, ProductHistory>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));

            CreateMap<ProductTextAttributeDto, ProductTextAttribute>();
            CreateMap<ProductNumberAttributeDto, ProductNumberAttribute>();

            CreateMap<ProductNumberAttribute, ProductNumberAttributeHistory>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.ProductNumberAttributeId, opt => opt.MapFrom(src => src.Id));

            CreateMap<ProductTextAttribute, ProductTextAttributeHistory>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.ProductTextAttributeId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Opinion, OpinionDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => (src.AppUser == null)?null:(int?)src.AppUser.Id))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => (src.AppUser == null)?null:src.AppUser.UserName))
            .ForMember(dest => dest.OpinionLikesNumber, opt => opt.MapFrom(src => src.OpinionLikes.Count()))
            .ForMember(dest => dest.CurrentUserOpinionLike, opt => opt.MapFrom<CurrentUserOpinionLikeResolver>());


            CreateMap<OpinionDto, Opinion>();

            CreateMap<OpinionLikeDto, OpinionLike>()
            .ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.UserId));
            CreateMap<OpinionLike, OpinionLikeDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.AppUserId));

            CreateMap<CartDto, Cart>();
            CreateMap<Cart, CartDto>();
            CreateMap<CartLineDto, CartLine>()
            .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => Guid.Parse(src.CartId)));
            CreateMap<CartLine, CartLineDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product==null?null:(double?)src.Product.Price))
            .ForMember(dest => dest.ActualPrice, opt => opt.MapFrom<CartLinePriceResolver>())
            .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom<CartLinePhotoResolver>())
            .ForMember(dest => dest.CartId, opt => opt.MapFrom(src => src.CartId.ToString()));
            
            // CreateMap<AppUser,MemberDto>()
            // .ForMember(dest=>dest.PhotoUrl,opt=>opt.MapFrom(src=>src.Photos.FirstOrDefault(x=>x.IsMain).Url))
            // .ForMember(dest=>dest.Age,opt=>opt.MapFrom(src=>src.DateOfBirth.CalculateAge()));
            // CreateMap<Photo,PhotoDto>();

            // CreateMap<MemberUpdateDto,AppUser>();
            // CreateMap<RegisterDto,AppUser>();
            // CreateMap<Message,MessageDto>()
            // .ForMember(dest=>dest.SenderPhotoUrl,opt=>opt.MapFrom(src=>src.Sender.Photos.FirstOrDefault(x=>x.IsMain).Url))
            // .ForMember(dest=>dest.RecipientPhotoUrl,opt=>opt.MapFrom(src=>src.Recipient.Photos.FirstOrDefault(x=>x.IsMain).Url));
        }
    }
}