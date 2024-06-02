using BlazorApp_Healthy.Client.Services.DataService;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp_Healthy.Client.Services.Comon
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
         where TEntity : class
    {
        private readonly IDataService _dataService;

        public Repository(IDataService dataService)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _dataService.GetAllAsync<TEntity>();

        public virtual async Task CreateAsync(TEntity entity)
        {
            await _dataService.CreateAsync(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            await _dataService.UpdateAsync(entity);
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            await _dataService.DeleteAsync<TEntity, TKey>(id);
        }

        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await _dataService.GetAsync<TEntity, TKey>(id);
        }

        public async Task SaveAsync()
        {
            await _dataService.SaveAsync();
        }
    }


}
