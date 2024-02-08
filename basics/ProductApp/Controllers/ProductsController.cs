using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet] // information sevyesinde olduğu için log kaydı düşmüyor -> IIS de çalışırken 
        public IActionResult GetAllProducts()
        {
            var products = new List<Product>()
            {
                new Product() {Id = 1, ProductName="Computer"},
                new Product() {Id = 2, ProductName="Keyboard"},
                new Product() {Id = 3, ProductName="Mouse"}
            };
            _logger.LogInformation("GetAllProducts action has been called.");
            return Ok(products);
        }

        [HttpPost] // production modda olduğu için log kaydı düşüyor -> IIS de çalışırken 
        public IActionResult GetAllProducts([FromBody] Product product)
        {
            _logger.LogWarning("Product has been created.");
            return StatusCode(201); // Created.
        }

        // Development modda her iki kısımda da log kaydı düşüyor
    }
}
