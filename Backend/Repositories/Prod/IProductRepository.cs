using AdityaSERA.Backend.Model.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdityaSERA.Backend.Repositories.Prod
{
    public interface IProductRepository
    {
        Task<Product> addProduct(Product product);
        Task<IEnumerable<Product>> getProduct();
        Task<Product> getOrderProductById(int productId);
    }
}
