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
using APM_Back.Helpers;

namespace APM_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IUriService _uriService;

        public ProductsController(IProductService productService, IUriService uriService)
        {
            this._productService = productService;
            this._uriService = uriService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var result = await this._productService.GetAll(filter);

            var pagedResponse = PaginationHelper.CreatePagedReponse<Product>(result.data,validFilter,result.totalRecords,_uriService,route);

            var response = new PagedResponse<IEnumerable<Product>>(result.data, filter.PageNumber, filter.PageSize);
            return Ok(pagedResponse);
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
