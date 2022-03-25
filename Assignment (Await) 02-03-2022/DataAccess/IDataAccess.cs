using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment__Await__02_03_2022.DataAccess
{
    internal interface IDataAccess<TEntity, in TPk> where TEntity : class
    {
       Task<IEnumerable<TEntity>> GetData();
      
       Task Create(TEntity entity);
       Task Update(TPk id, TEntity entity);
       Task Delete(TPk id);

    }

}
