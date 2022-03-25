using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02_03_2022.DataAccess
{
    internal interface IDataAccess<TEntity, in TPk> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetDataAsync();
        Task<TEntity> GetDataAsync(TPk id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TPk id, TEntity entity);
        Task<TEntity> DeleteAsync(TPk id);
    }
}
