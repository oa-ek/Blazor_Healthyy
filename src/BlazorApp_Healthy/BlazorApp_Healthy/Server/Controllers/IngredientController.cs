using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp_Healthy.Server.Services;
using BlazorApp_Healthy.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp_Healthy.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IngredientService _ingredientService;

        public IngredientController(IngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ingredient>>> GetAllIngredients()
        {
            var ingredients = await _ingredientService.GetAllIngredientsAsync();
            return Ok(ingredients);
        }
        [HttpPost]
        public async Task<ActionResult<Ingredient>> AddIngredient(Ingredient ingredient)
        {
            var newIngredient = await _ingredientService.AddIngredientAsync(ingredient);
            return CreatedAtAction(nameof(GetAllIngredients), new { id = newIngredient.Id }, newIngredient);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIngredient(Guid id)
        {
            var ingredientToDelete = await _ingredientService.GetIngredientByIdAsync(id);
            if (ingredientToDelete == null)
            {
                return NotFound();
            }

            await _ingredientService.DeleteIngredientAsync(ingredientToDelete);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredientById(Guid id)
        {
            var ingredient = await _ingredientService.GetIngredientByIdAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ingredient>> UpdateIngredient(Guid id, Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                return BadRequest();
            }

            var updatedIngredient = await _ingredientService.UpdateIngredientAsync(ingredient);
            return Ok(updatedIngredient);
        }
    }
}