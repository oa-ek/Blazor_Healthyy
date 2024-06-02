using BlazorApp_Healthy.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlazorApp_Healthy.Client.Services.Comon;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using BlazorApp_Healthy.Server.Data;

namespace BlazorApp_Healthy.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeService _recipeService;

        public RecipeController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Recipe>>> GetAllRecipes()
        {
            var recipes = await _recipeService.GetAllRecipesAsync();
            return Ok(recipes);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> AddRecipe(Recipe recipe)
        {
            var newRecipe = await _recipeService.AddRecipeAsync(recipe);
            return CreatedAtAction(nameof(GetAllRecipes), new { id = newRecipe.Id }, newRecipe);
        }
    }

}
