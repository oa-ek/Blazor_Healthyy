namespace BlazorApp_Healthy.Client.Services.DataService
{
    public interface IDataService
    {
        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class;
        Task CreateAsync<TEntity>(TEntity entity) where TEntity : class;
        Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class;
        Task DeleteAsync<TEntity, TKey>(TKey id) where TEntity : class;
        Task<TEntity> GetAsync<TEntity, TKey>(TKey id) where TEntity : class;
        Task SaveAsync();
    }
}
