using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        [Route("add-product")]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() {Id = Guid.NewGuid(), ProductName = "ASD", Price = 100, CreateDate = DateTime.UtcNow, Stock=10},
                new() {Id = Guid.NewGuid(), ProductName = "ASDDD", Price = 200, CreateDate = DateTime.UtcNow, Stock=20},
            });
            await _productWriteRepository.SaveAsync();
        }
        [HttpGet]
        [Route("get-product-by-id/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
