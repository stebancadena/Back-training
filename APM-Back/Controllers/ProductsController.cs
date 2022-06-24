using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APM_Back.Models;
using APM_Back.ActionFilters;
using APM_Back.Services;

namespace APM_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var response = await this._productService.GetAll(filter, route);
            return Ok(response);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidateEntityExistsClass<Product>))]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await this._productService.GetBy(id);
            var response = new Response<Product>(product);
            return Ok(response);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationActionFilterClass))]
        public async Task<IActionResult> PutProduct(Guid id, Product product)
        {

            await this._productService.Update(id, product);
            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        [ServiceFilter(typeof(ValidationActionFilterClass))]
        public async Task<IActionResult> PostProduct(Product product)
        {
            var createdProduct = await this._productService.Create(product);
            return CreatedAtAction("GetProduct", new { id = createdProduct.ProductId }, createdProduct);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateEntityExistsClass<Product>))]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var deletedProduct = await this._productService.Delete(id);
            return Ok(deletedProduct);
        }
    }
}
