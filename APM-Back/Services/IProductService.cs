using APM_Back.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APM_Back.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetBy(Guid id);
        Task<Product> Create(Product product);
        Task<Product> Update(Guid id, Product product);
        Task<Product> Delete(Guid id);
    }
}
