using Application.Feature.Commands.Provider.UpdateProvider;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping.ProviderMapping
{
    public class UpdateProdviderMapping : Profile
    {
        public UpdateProdviderMapping()
        {
            CreateMap<UpdateProviderCommand, Provider>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CompanyInfo, opt => opt.MapFrom(src => src.CompanyInfo))
                    .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo));

            CreateMap<UpdateCompanyCommand, CompanyInfo>();

            CreateMap<UpdateContactCommand, ContactInfo>();
        }
    }
}
