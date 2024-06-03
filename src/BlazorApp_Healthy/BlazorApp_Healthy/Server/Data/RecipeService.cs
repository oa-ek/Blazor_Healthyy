using BlazorApp_Healthy.Shared;

namespace BlazorApp_Healthy.Server.Data
{
    public class RecipeService
    {
        private readonly DataContext _context;

        public RecipeService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Recipe>> GetAllRecipesAsync()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task<Recipe> AddRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }


        public async Task<Recipe> DeleteRecipeAsync(Guid id)
        {
            var recipeToDelete = await _context.Recipes.FindAsync(id);
            if (recipeToDelete != null)
            {
                _context.Recipes.Remove(recipeToDelete);
                await _context.SaveChangesAsync();
            }
            return recipeToDelete;
        }
        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            return await _context.Ingredients.ToListAsync();
        }
    }
}