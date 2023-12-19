using Application.Exceptions;
using Domain.Common.Interfaces;
using Domain.Entities;
using System;

namespace Application.Services
{
    public class ProviderService : IService<Provider>
    {
        private readonly IRepository<Provider> _providerRepository;

        public ProviderService(IRepository<Provider> providerRepository)
        {
            _providerRepository = providerRepository;
        }

        public async Task<string> Create(Provider entity)
        {
            await Exists(entity.NIT); 
            await _providerRepository.CreateAsync(entity);
            return entity.Id.ToString();
        }

        public async Task Delete(string id)
        {
            await GetById(id);
            await _providerRepository.DeleteAsync(id);
        }

        public async Task<List<Provider>> GetAll()
        {
           var response = await _providerRepository.GetAllAsync();
            return response;
        }

        public async Task<Provider> GetById(string id)
        {
            var providerFound = await _providerRepository.GetByIdAsync(id);
            _ = providerFound ?? throw new NotFoundException(Message.ItWasNotFound);
            return providerFound;
        }

        public async Task Update(string id, Provider entity)
        {
            var existigProvider = await GetById(id);
            existigProvider.Update(entity.ContactInfo, entity.CompanyInfo, entity.IsActive);
            await _providerRepository.UpdateAsync(existigProvider);
        }

        private async Task<bool> Exists(int nit)
        {
            var isExists = await _providerRepository.ExistsAsync(p => p.NIT == nit);
            return (!isExists)? isExists: throw new ExistingRecordException($"Proveedor con NIT {nit} ya existe.");
        }
    }
}
