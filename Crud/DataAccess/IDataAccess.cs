using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DataAccess
{
    internal interface IDataAccess<TEntity, in TPk> where TEntity : class
    {
        IEnumerable<TEntity> GetData();
        TEntity GetData(TPk id);
        TEntity Create(TEntity entity);
        TEntity Update(TPk id, TEntity entity);
        TEntity Delete(TPk id);
        
    }
internal interface IDataAccess2<TEntity,in TKey> where TEntity: class
    {
        void GetallEmployeebyDeptName(TKey id);
        void GetallEmployeeMaxSalary(TKey id);
        void GetSumSalaryByDeptName(TKey id);
        void GetAllEmployeeByLocation(TKey id);
    }
}
