using Application.Common.Wrappers;
using MediatR;

namespace Application.Feature.Queires.ProviderQueries.GetAll
{
    public record GetAllProviders:IRequest<Response<List<GetAllProvidersDto>>>;
    
}
