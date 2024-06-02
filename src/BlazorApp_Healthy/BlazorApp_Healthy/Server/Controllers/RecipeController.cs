﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp_Healthy.Server.Data;
using BlazorApp_Healthy.Server.Services;
using BlazorApp_Healthy.Shared;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<Recipe>> CreateRecipe(Recipe recipe)
        {
            var createdRecipe = await _recipeService.AddRecipeAsync(recipe);
            return CreatedAtAction(nameof(GetAllRecipes), new { id = createdRecipe.Id }, createdRecipe);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRecipe(Guid id)
        {
            var recipeToDelete = await _recipeService.GetRecipeByIdAsync(id);
            if (recipeToDelete == null)
            {
                return NotFound();
            }

            await _recipeService.DeleteRecipeAsync(recipeToDelete);
            return NoContent();
        }
    }
}
