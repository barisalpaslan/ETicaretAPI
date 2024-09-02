using ETicaretAPI.Application.Repositories;
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
        public async void Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() {Id = Guid.NewGuid(), ProductName = "ASD", Price = 100, CreateDate = DateTime.UtcNow, Stock=10},
                new() {Id = Guid.NewGuid(), ProductName = "ASDDD", Price = 200, CreateDate = DateTime.UtcNow, Stock=20},
            });
            await _productWriteRepository.SaveAsync();
        }
    }
}
