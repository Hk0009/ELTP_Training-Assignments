using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_03_11_2022.DataAccess
{
    public interface IDataAccess<TEntity, in TPk> where TEntity : class
    {
       // Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> CreateAsync(TEntity entity);
       // Task<TEntity> UpdateAsync(TEntity entity, TPk id);
       //Task<TEntity> DeleteAsync(TPk id);

    }

}
