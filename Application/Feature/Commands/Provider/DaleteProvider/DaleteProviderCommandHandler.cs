using Application.Common.Wrappers;
using Application.Services;
using Domain.Common.Exceptions;
using MediatR;

namespace Application.Feature.Commands.Provider.DaleteProvider
{
    public class DaleteProviderCommandHandler : IRequestHandler<DaleteProviderCommand, Response<string>>
    {
        private readonly ProviderService _service;

        public DaleteProviderCommandHandler(ProviderService service)
        {
            _service = service;
        }

        public async Task<Response<string>> Handle(DaleteProviderCommand request, CancellationToken cancellationToken)
        {
            var existingProvider = await _service.GetById(request.Id);
            if (existingProvider is null) {
                throw new ApiExceptionHandler(Message.ItWasNotFound); 
            }
            await _service.Delete(request.Id);
            return new Response<string>(Message.DeletedSuccessfully);

        }
    }
}
