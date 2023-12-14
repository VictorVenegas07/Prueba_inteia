using Application.Common.Exceptions;
using Domain.Common;
using Domain.Common.Exceptions;
using Domain.Entities;

namespace Application.Services
{
    public class ProviderService 
    {
        private readonly IRepository<Provider> _providerRepository;

        public ProviderService(IRepository<Provider> providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<string> Create(Provider entity)
        {
            await _providerRepository.CreateAsync(entity);
            return Message.RegisteredSuccessfully;
        }

        public async Task<string> Delete(string id)
        {
            await GetById(id);
            await _providerRepository.DeleteAsync(id);
            return Message.UpdatedSuccessfully;
        }

        public async Task<List<Provider>> GetAll()
        {
           return await _providerRepository.GetAllAsync();
        }

        public async Task<Provider> GetById(string id)
        {
            var existingProvider = await _providerRepository.GetByIdAsync(id);

            if (existingProvider is null)
            {
                throw new ApiExceptionHandler(Message.ItWasNotFound);
            }
            return existingProvider;
        }

        public async Task<string> Update(string id, Provider entity)
        {
            var existigProvider = await GetById(id);
            existigProvider.Update(entity.ContactInfo, entity.CompanyInfo);
            await _providerRepository.UpdateAsync(existigProvider);
            return Message.UpdatedSuccessfully;
        }
    }
}
