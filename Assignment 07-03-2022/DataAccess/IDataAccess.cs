using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_07_03_2022.DataAccess
{
    internal interface IDataAccess <TEntity ,in TPk> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity, TPk id);
        Task<TEntity> DeleteAsync(TPk id);  
    }
    
}
