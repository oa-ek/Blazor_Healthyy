using System.Net.Http.Json;

namespace BlazorApp_Healthy.Client.Services.DataService
{
    public class HttpDataService : IDataService
    {
        private readonly HttpClient _httpClient;

        public HttpDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TEntity>>($"api/{typeof(TEntity).Name.ToLower()}");
        }

        public async Task CreateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _httpClient.PostAsJsonAsync($"api/{typeof(TEntity).Name.ToLower()}", entity);
        }

        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            await _httpClient.PutAsJsonAsync($"api/{typeof(TEntity).Name.ToLower()}", entity);
        }

        public async Task DeleteAsync<TEntity, TKey>(TKey id) where TEntity : class
        {
            await _httpClient.DeleteAsync($"api/{typeof(TEntity).Name.ToLower()}/{id}");
        }

        public async Task<TEntity> GetAsync<TEntity, TKey>(TKey id) where TEntity : class
        {
            return await _httpClient.GetFromJsonAsync<TEntity>($"api/{typeof(TEntity).Name.ToLower()}/{id}");
        }

        public Task SaveAsync()
        {
            // Save changes are handled server-side in HTTP service methods
            return Task.CompletedTask;
        }
    }
}
