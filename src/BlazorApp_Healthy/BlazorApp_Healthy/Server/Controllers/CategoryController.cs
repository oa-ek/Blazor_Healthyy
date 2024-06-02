using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp_Healthy.Server.Services;
using BlazorApp_Healthy.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp_Healthy.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            var newCategory = await _categoryService.AddCategoryAsync(category);
            return CreatedAtAction(nameof(GetAllCategories), new { id = newCategory.Id }, newCategory);
        }
    }
}
