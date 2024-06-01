using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp_Healthy.Shared;
using BlazorApp_Healthy.Client.Services.Comon;

namespace BlazorApp_Healthy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Shared.Category, Guid> _categoryRepository;

        public CategoryController(IRepository<Shared.Category, Guid> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shared.Category>>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shared.Category>> GetCategoryById(Guid id)
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Shared.Category>> CreateCategory(Shared.Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.CreateAsync(category);
                return Ok(category);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, Shared.Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            try
            {
                await _categoryRepository.UpdateAsync(category);
            }
            catch (Exception)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            await _categoryRepository.DeleteAsync(id);

            return NoContent();
        }

        private bool CategoryExists(Guid id)
        {
            // Check if category exists in your repository
            // Implement this according to your repository logic
            throw new NotImplementedException();
        }
    }
}
