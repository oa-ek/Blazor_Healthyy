
﻿using System.Collections.Generic;
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
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            var createdCategory = await _categoryService.AddCategoryAsync(category);
            return CreatedAtAction(nameof(GetAllCategories), new { id = createdCategory.Id }, createdCategory);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var categoryToDelete = await _categoryService.GetCategoryByIdAsync(id);
            if (categoryToDelete == null)
            {
                return NotFound();
            }

            await _categoryService.DeleteCategoryAsync(categoryToDelete);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(Guid id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            var updatedCategory = await _categoryService.UpdateCategoryAsync(category);
            return Ok(updatedCategory);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(Guid id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
    }
}
