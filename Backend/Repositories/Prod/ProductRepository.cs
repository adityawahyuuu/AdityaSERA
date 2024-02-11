using AdityaSERA.Backend.Model.Domain;
using AdityaSERA.Backend.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdityaSERA.Backend.Repositories.Prod
{
    public class ProductRepository : IProductRepository
    {
        private readonly AdityaSERADbContext _dbContext;

        public ProductRepository(AdityaSERADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> addProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> getProduct()
        {
            var products = await _dbContext.Products.ToListAsync();
            if (products.Count == 0) return null;
            return products;
        }

        public async Task<Product> getOrderProductById(int productId)
        {
            var orderProduct = await _dbContext.Products
                .FirstOrDefaultAsync(ors => ors.ProductID == productId);

            return orderProduct;
        }
    }
}
