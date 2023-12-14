using Application.Common.Wrappers;
using Application.Services;
using AutoMapper;
using EntityProvider = Domain.Entities.Provider;
using MediatR;

namespace Application.Feature.Commands.Provider.CraeteProvider
{
    public class CraeteProviderCommandHandler : IRequestHandler<CraeteProviderCommand, Response<string>>
    {
        private readonly ProviderService _service;
        private readonly IMapper _mapper;

        public CraeteProviderCommandHandler(ProviderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CraeteProviderCommand request, CancellationToken cancellationToken)
        {
            var provider = _mapper.Map<EntityProvider>(request);
            var response = await _service.Create(provider);
            return new Response<string>( response, Message.RegisteredSuccessfully);
        }
    }
}
