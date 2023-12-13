using Domain.Common;
using Domain.Entities;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IRepository<Provider> _repository;

        public ProviderController(IRepository<Provider> repository)
        {
            _repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> Post(Provider provider)
        {
             await _repository.Create(provider);
            return Ok("OK");
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _repository.GetAll();
            return Ok(list);
        }
    }
}
