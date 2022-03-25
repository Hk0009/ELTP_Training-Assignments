using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_16_03_2022_final.Services
{
    public interface IService
    {
        public interface IService<TEntity, in TPk> where TEntity: class
            {
            Task<IEnumerable<TEntity>> GetAsync();
            Task<TEntity> GetAsync(TPk id);
            Task<TEntity> CreateAsync(TEntity entity);
            Task<TEntity> UpdateAsync(TPk id, TEntity entity);

            Task<TEntity> DeleteAsync(TPk id);

        }

    }
}
