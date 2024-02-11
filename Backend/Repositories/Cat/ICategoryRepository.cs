using AdityaSERA.Backend.Model.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdityaSERA.Backend.Repositories.Cat
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> getCategory();
        Task<Category> getCategoryByName(string categoryName);
    }
}
