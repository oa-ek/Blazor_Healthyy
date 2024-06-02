using BlazorApp_Healthy.Client.Services.Comon;
namespace BlazorApp_Healthy.Client.Services.Comon
{
    public interface IRepository<TEntity, TKey>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TKey id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey id);
    }
}
