using Application.Feature.Commands.Provider.CraeteProvider;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping.ProviderMapping
{
    public class ProviderProfile: Profile
    {
        public ProviderProfile()
        {
            CreateMap<CraeteProviderCommand, Provider>()
            .ForMember(dest => dest.NIT, opt => opt.MapFrom(src => src.NIT))
            .ForMember(dest => dest.CompanyInfo, opt => opt.MapFrom(src => src.CompanyInfo))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true)) 
            .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo));

            CreateMap<CreateCompanyCommand, CompanyInfo>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Addressstring))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<CraeteContactCommand, ContactInfo>()
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName))
                .ForMember(dest => dest.ContactEmail, opt => opt.MapFrom(src => src.ContactEmail));
        }
    }
}
