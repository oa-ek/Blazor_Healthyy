using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp_Healthy.Server.Data;
using BlazorApp_Healthy.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp_Healthy.Server.Services
{
    public class CategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

    }
}
