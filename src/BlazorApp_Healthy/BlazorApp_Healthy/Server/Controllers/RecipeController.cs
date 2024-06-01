using BlazorApp_Healthy.Client.Services.Comon;
using BlazorApp_Healthy.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp_Healthy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRepository<Recipe, Guid> _recipeRepository;

        public RecipeController(IRepository<Recipe, Guid> recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetAllRecipes()
        {
            var recipes = await _recipeRepository.GetAllAsync();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipeById(Guid id)
        {
            var recipe = await _recipeRepository.GetAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> CreateRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                await _recipeRepository.CreateAsync(recipe);
                return Ok(recipe);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecipe(Guid id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            // Очікуємо завершення виконання методу RecipeExists
            if (!await RecipeExists(id))
            {
                return NotFound();
            }

            try
            {
                await _recipeRepository.UpdateAsync(recipe);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(Guid id)
        {
            var recipe = await _recipeRepository.GetAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            await _recipeRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> RecipeExists(Guid id)
        {
            var recipe = await _recipeRepository.GetAsync(id);
            return recipe != null; // Поверне true, якщо рецепт знайдено, або false, якщо ні.
        }
    }
}
