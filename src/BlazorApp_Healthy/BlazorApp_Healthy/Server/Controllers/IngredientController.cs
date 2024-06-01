using BlazorApp_Healthy.Client.Services.Comon;
using BlazorApp_Healthy.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp_Healthy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IRepository<Ingredient, Guid> _ingredientRepository;

        public IngredientController(IRepository<Ingredient, Guid> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetAllIngredients()
        {
            var ingredients = await _ingredientRepository.GetAllAsync();
            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredientById(Guid id)
        {
            var ingredient = await _ingredientRepository.GetAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient);
        }

        [HttpPost]
        public async Task<ActionResult<Ingredient>> CreateIngredient(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                await _ingredientRepository.CreateAsync(ingredient);
                return Ok(ingredient);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredient(Guid id, Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                return BadRequest();
            }

            try
            {
                await _ingredientRepository.UpdateAsync(ingredient);
            }
            catch (Exception)
            {
                if (!IngredientExists(id))
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
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            var ingredient = await _ingredientRepository.GetAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            await _ingredientRepository.DeleteAsync(id);

            return NoContent();
        }

        private bool IngredientExists(Guid id)
        {
            // Check if ingredient exists in your repository
            // Implement this according to your repository logic
            throw new NotImplementedException();
        }
    }
}
