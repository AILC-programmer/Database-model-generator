using System;
using System.Threading.Tasks;

namespace CafeParty.WindowsApp.DataLayers
{
    public interface IRepository<TEntity>
    {
        Task<int> AddAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<TEntity> FindAsync(params object[] keys);
        Task<System.Collections.Generic.List<TEntity>> FindAllAsync();
        Task<int> CountAsync();

        event Action<TEntity> OnAdded;
        event Action<TEntity> OnUpdated;
        event Action<TEntity> OnDeleted;
    }
}
