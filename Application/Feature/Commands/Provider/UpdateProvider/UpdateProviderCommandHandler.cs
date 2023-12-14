using Application.Common.Wrappers;
using Application.Services;
using AutoMapper;
using MediatR;
using EntityProvider = Domain.Entities.Provider;

namespace Application.Feature.Commands.Provider.UpdateProvider
{
    public class UpdateProviderCommandHandler : IRequestHandler<UpdateProviderCommand, Response<string>>
    {
        private readonly ProviderService _service;
        private readonly IMapper _mapper;


        public UpdateProviderCommandHandler(ProviderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
        {
           
            var providerUpdating = _mapper.Map<EntityProvider>(request);
            await _service.Update(request.Id,providerUpdating);
            
            return new Response<string>(Message.UpdatedSuccessfully);
        }
    }
}
