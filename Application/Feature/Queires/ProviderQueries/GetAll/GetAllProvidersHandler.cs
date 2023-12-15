using Application.Common.Wrappers;
using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Feature.Queires.ProviderQueries.GetAll
{
    public class GetAllProvidersHandler : IRequestHandler<GetAllProviders, Response<List<GetAllProvidersDto>>>
    {
        private readonly ProviderService _service;
        private readonly IMapper _mapper;
        public GetAllProvidersHandler(IMapper mapper, ProviderService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public async Task<Response<List<GetAllProvidersDto>>> Handle(GetAllProviders request, CancellationToken cancellationToken)
        {
            var response = await _service.GetAll();
            var listProvider = response.Select(x => _mapper.Map<GetAllProvidersDto>(x)).ToList();
            return new Response<List<GetAllProvidersDto>>(listProvider, Message.SuccessfulQuery);
        }
    }
}
