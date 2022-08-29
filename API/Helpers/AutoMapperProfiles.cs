using System;
using System.Linq;
using API.DBAccess.Entities;
using API.DTOs;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Agreement,AgreementDto>();
            CreateMap<AgreementDto,UserAgreement>()
            .ForMember(dest=>dest.AgreementId,opt=>opt.MapFrom(src=>src.Id))
            .ForMember(dest=>dest.Value,opt=>opt.MapFrom(src=>src.Checked));
            CreateMap<RegisterDto,AppUser>()
            .ForMember(dest=>dest.UserName,opt=>opt.MapFrom(src=>src.Email));
            CreateMap<AppUser,AppUserHistory>()
            .ForSourceMember(x => x.Id, y => y.DoNotValidate())
            .ForMember(dest=>dest.AppUserId,opt=>opt.MapFrom(src=>src.Id))
            .ForMember(x => x.Id, opt => opt.MapFrom(src => 0));
            CreateMap<UserAgreement,UserAgreementHistory>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => 0));
            CreateMap<AppUser,AccountDataDto>();
            CreateMap<UserAgreement,UserAgreementDto>()
            .ForMember(dest=>dest.Contents,opt=>opt.MapFrom(src=>src.Agreement.Contents));
            CreateMap<Agreement,UserAgreementDto>()
            .ForMember(x => x.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest=>dest.AgreementId,opt=>opt.MapFrom(src=>src.Id))
            .ForMember(dest=>dest.Contents,opt=>opt.MapFrom(src=>src.Contents));
            CreateMap<ShippingAddress,ShippingAddressDto>();
            CreateMap<ShippingAddressDto,ShippingAddress>();
            CreateMap<ShippingAddress,ShippingAddressHistory>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.ShippingAddressId, opt => opt.MapFrom(src => src.Id));
            CreateMap<AttributeDto, DBAccess.Entities.Attribute>();
            CreateMap<DBAccess.Entities.Attribute,AttributeDto>();
            CreateMap<DBAccess.Entities.Attribute,AttributeBasicDto>();
            CreateMap<DBAccess.Entities.Attribute,AttributeHistory>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.AttributeId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CategoryAttributeDto,CategoryAttribute>();

            CreateMap<CategoryDto,Category>();
            CreateMap<Category,CategoryHistory>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Id));
            CreateMap<CategoryAttribute,CategoryAttributeHistory>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.CategoryAttributeId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CategoryAttribute,CategoryAttributeDto>();
            CreateMap<Category,CategoryDto>();
            CreateMap<Category,CategoryTreeItemDto>();

            CreateMap<Product,ProductDto>();
            CreateMap<Photo,PhotoDto>();

            CreateMap<CategoryAttribute,ProductTextAttributeDto>();
            CreateMap<CategoryAttribute,ProductNumberAttributeDto>()
            .ForMember(dest => dest.DecimalPlaces, opt => opt.MapFrom(src => src.Attribute!=null?src.Attribute.DecimalPlaces:0));

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