using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorApp_Healthy.Server.Data;
using BlazorApp_Healthy.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp_Healthy.Server.Services
{
    public class IngredientService
    {
        private readonly DataContext _context;

        public IngredientService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            return await _context.Ingredients.ToListAsync();
        }
        public async Task<Ingredient> AddIngredientAsync(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            return ingredient;
        }
    }
}