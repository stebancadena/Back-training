using APM_Back.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APM_Back.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Product> Create(Product product)
        {
            product.ProductId = Guid.NewGuid();
            _dataContext.Products.Add(product);
            await _dataContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Delete(Product product)
        {
            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product> GetBy(Guid id)
        {
            var product = await _dataContext.Products.FindAsync(id);
            return product;
        }

        public async Task<Product> Update(Guid id, Product product)
        {
            var productUpdated = _dataContext.Entry(product).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
            return null;
        }
    }
}
