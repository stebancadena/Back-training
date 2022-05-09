using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var result = await this._productService.GetAll();
            return this.Ok(result);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        [ServiceFilter(typeof(ValidateEntityExistsClass<Product>))]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var product = await this._productService.GetBy(id);
            return Ok(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationActionFilterClass))]
        public async Task<IActionResult> PutProduct(Guid id, Product product)
        {

            await this._productService.Update(id, product);
            return NoContent();

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ProductExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
        }

        // POST: api/Products
        [HttpPost]
        [ServiceFilter(typeof(ValidationActionFilterClass))]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            var createdProduct = await this._productService.Create(product);
            return CreatedAtAction("GetProduct", new { id = createdProduct.ProductId }, createdProduct);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateEntityExistsClass<Product>))]
        public async Task<ActionResult<Product>> DeleteProduct(Guid id)
        {
            var deletedProduct = await this._productService.Delete(id);
            return deletedProduct;
        }
    }
}
