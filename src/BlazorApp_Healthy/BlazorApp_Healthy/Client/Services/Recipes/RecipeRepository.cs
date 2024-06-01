using BlazorApp_Healthy.Shared;
using System.Net.Http.Json;

namespace BlazorApp_Healthy.Client.Services.Recipes
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly HttpClient _httpClient;

        public RecipeRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Category>>("api/categories");
        }

        public async Task<Category> GetCategoryAsync(Guid categoryId)
        {
            return await _httpClient.GetFromJsonAsync<Category>($"api/categories/{categoryId}");
        }

        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Ingredient>>("api/ingredients");
        }

        public async Task<Ingredient> GetIngredientAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Ingredient>($"api/ingredients/{id}");
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Recipe>>("api/recipe");
        }

        public async Task<Recipe> GetAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Recipe>($"api/recipe/{id}");
        }

        public async Task CreateAsync(Recipe recipe)
        {
            await _httpClient.PostAsJsonAsync("api/recipe", recipe);
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            await _httpClient.PutAsJsonAsync($"api/recipe/{recipe.Id}", recipe);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/recipe/{id}");
        }
    }
}
