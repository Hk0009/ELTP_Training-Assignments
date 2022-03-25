using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asiignment_22_02_2022.DataAccess
{
    internal interface IDataAccess<TEntity> where TEntity : class
    {
        void Add();
        void Update();
        void Delete();
        void Read();

    }
}
