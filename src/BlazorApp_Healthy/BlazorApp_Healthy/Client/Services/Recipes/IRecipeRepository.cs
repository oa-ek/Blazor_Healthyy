using BlazorApp_Healthy.Shared;

namespace BlazorApp_Healthy.Client.Services.Recipes
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryAsync(Guid categoryId);
        Task<List<Ingredient>> GetAllIngredientsAsync();
        Task<Ingredient> GetIngredientAsync(Guid id);
        Task<IEnumerable<Recipe>> GetAllAsync();
        Task<Recipe> GetAsync(Guid id);
        Task CreateAsync(Recipe recipe);
        Task UpdateAsync(Recipe recipe);
        Task DeleteAsync(Guid id);
    }
}
