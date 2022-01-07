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
            .ForMember(dest=>dest.AppUserId,opt=>opt.MapFrom(src=>src.Id));
            CreateMap<UserAgreement,UserAgreementHistory>();
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