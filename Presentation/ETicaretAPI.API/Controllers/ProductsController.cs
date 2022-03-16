using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10 },
                new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 120, CreatedDate = DateTime.UtcNow, Stock = 12 },
                new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 130, CreatedDate = DateTime.UtcNow, Stock = 30 },
            });

            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(String productId)
        {
            var product = await _productReadRepository.GetByIdAsync(productId,false);
            return Ok(product);
        }
    }
}
