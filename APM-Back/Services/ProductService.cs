using APM_Back.Data;
using APM_Back.Helpers;
using APM_Back.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel;
using System.Threading.Tasks;

namespace APM_Back.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IUriService _uriService;
        public ProductService(IProductRepository repository, IUriService uriService)
        {
            this._repository = repository;
            this._uriService = uriService;
        }

        public async Task<Product> Create(Product product)
        {
            return await this._repository.Create(product);
        }

        public async Task<Product> Delete(Guid id)
        {
            var product = await this._repository.GetBy(id);
            var productDeleted = await this._repository.Delete(product);
            return productDeleted;
        }

        public async Task<PagedResponse<IEnumerable<Product>>> GetAll(PaginationFilter filter, string route)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var result = await this._repository.GetAll(filter);

            var pagedRespose = PaginationHelper.CreatePagedReponse<Product>(result.data, validFilter, result.totalRecords, _uriService, route);
            return pagedRespose;
        }

        public Task<Product> GetBy(Guid id)
        {
            return this._repository.GetBy(id);
        }

        public Task<Product> Update(Guid id, Product product)
        {
            if(id != product.ProductId)
            {
                throw new Exception("Not matches the param id with the productId");
            }
            var updatedBuilding = this._repository.Update(id, product);
            return updatedBuilding;
        }
    }
}
