using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_07_03_2022.Models;
using Microsoft.EntityFrameworkCore;
namespace Assignment_07_03_2022.DataAccess
{
    internal class EmployeeDataAccess : IDataAccess<ComEmployee, int>
    {
        MydatabaseContext ctx;
        public EmployeeDataAccess()
        {
            ctx = new MydatabaseContext();  
        }
        async Task<IEnumerable<ComEmployee>> IDataAccess<ComEmployee, int>.GetAsync()
        {
            var res = await ctx.ComEmployees.ToListAsync(); 
            return res; 
        }
        async Task<ComEmployee> IDataAccess<ComEmployee, int>.CreateAsync(ComEmployee entity)
        {
            var res = await ctx.ComEmployees.AddAsync(entity);  
            await ctx.SaveChangesAsync();
            return res.Entity;

        }
        async Task<ComEmployee?> IDataAccess<ComEmployee, int>.DeleteAsync(int id)
        {
            var EmpDel = await ctx.ComEmployees.FindAsync(id);
            if (EmpDel == null)
            {
                return null;
            }
            ctx.ComEmployees.Remove(EmpDel);
            await ctx.SaveChangesAsync();   
            return EmpDel;  
        }
        async Task<ComEmployee?> IDataAccess<ComEmployee, int>.UpdateAsync(ComEmployee entity, int id)
        {
            var empUpdate = await ctx.ComEmployees.FindAsync(id);
            if (empUpdate == null)
            {
                return null;

            }
            empUpdate.EmpName = entity.EmpName;
            empUpdate.Designation=entity.Designation;
            empUpdate.DeptNo= entity.DeptNo;
            empUpdate.Email=entity.Email;
            empUpdate.DeptNo= entity.DeptNo;
            await ctx.SaveChangesAsync();
            return empUpdate;

        }

    }
}
