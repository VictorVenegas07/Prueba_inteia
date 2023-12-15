using Application.Feature.Queires.ProviderQueries.GetAll;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping.ProviderMapping
{
    public class GetAllProvidersProfile: Profile
    {
        public GetAllProvidersProfile()
        {
            CreateMap<Provider, GetAllProvidersDto>()
           .ForMember(dest => dest.NIT, opt => opt.MapFrom(src => src.NIT))
           .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.CompanyInfo))
           .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
           .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.ContactInfo));

            CreateMap<CompanyInfo, Company>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<ContactInfo, Contact>()
                .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName))
                .ForMember(dest => dest.ContactEmail, opt => opt.MapFrom(src => src.ContactEmail));
        }

    }
}

