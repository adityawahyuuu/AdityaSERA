using AdityaSERA.Backend.Model.Domain;
using AdityaSERA.Backend.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdityaSERA.Backend.Repositories.Cat
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AdityaSERADbContext _dbContext;

        public CategoryRepository(AdityaSERADbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> getCategory()
        {
            var categories = await _dbContext.Category.ToListAsync();
            if (categories.Count == 0) return null;
            return categories;
        }

        public async Task<Category> getCategoryByName(string categoryName)
        {
            var category = await _dbContext.Category
                .FirstOrDefaultAsync(c => c.CategoryName == categoryName);
            if (category == null) return null;
            return category;
        }

        public async Task<Category> createCategory(Category category)
        {
            await _dbContext.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }
    }
}
