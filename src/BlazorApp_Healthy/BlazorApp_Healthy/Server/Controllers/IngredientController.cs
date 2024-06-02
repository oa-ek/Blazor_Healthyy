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

    }
}
