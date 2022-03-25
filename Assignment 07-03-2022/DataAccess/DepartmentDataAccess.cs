using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_07_03_2022.Models;
using Microsoft.EntityFrameworkCore;
namespace Assignment_07_03_2022.DataAccess
{
    internal class DepartmentDataAccess :IDataAccess<Mydatabase, int >
    {
        MydatabaseContext ctx;
        public DepartmentDataAccess()
        {
            ctx = new MydatabaseContext();  
        }
        async Task<IEnumerable<Mydatabase>> IDataAccess<Mydatabase, int>.GetAsync()
        {
            try
            {

                var res = await ctx.Mydatabases.ToListAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //return Enumerable.Empty<Mydatabase>();  
           
        }
        async Task<Mydatabase> IDataAccess<Mydatabase , int>.CreateAsync(Mydatabase entity)
        {
            try
            {
                var result = await ctx.Mydatabases.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity;

            }
            catch (Exception ex)
            {

                throw ex;
            }
          
            
        }
        async Task<Mydatabase?> IDataAccess<Mydatabase, int>.DeleteAsync(int id)
        {
            var result = await ctx.Mydatabases.FindAsync(id);
             
            if (result == null)
            {
                return null;
            }
            ctx.Mydatabases.Remove(result);
            await ctx.SaveChangesAsync();
            return result;
        }
        async Task<Mydatabase?> IDataAccess<Mydatabase, int>.UpdateAsync(Mydatabase entity , int id)
        {
            try
            {
                var deptToUpdate = await ctx.Mydatabases.FindAsync(id);
                if (deptToUpdate == null)
                {
                    return null;
                }
                deptToUpdate.DeptName = entity.DeptName;
                deptToUpdate.Capctay = entity.Capctay;
                deptToUpdate.Location = entity.Location;
                await ctx.SaveChangesAsync();
                return deptToUpdate;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           // return entity;  
            
        }



    }
}
