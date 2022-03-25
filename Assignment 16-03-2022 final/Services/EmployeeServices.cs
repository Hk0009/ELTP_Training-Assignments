
using Assignment_16_03_2022_final.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Assignment_16_03_2022_final.Services.IService;
namespace Assignment_16_03_2022_final.Services
{
    public class EmployeeServices : IService<ComEmployee, int>
    {
        private readonly MydatabaseContext ctx;

        //inject the DemoContext
        public EmployeeServices(MydatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        async Task<ComEmployee> IService<ComEmployee, int>.CreateAsync(ComEmployee entity)
        {
            var res = await ctx.ComEmployees.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        async Task<ComEmployee> IService<ComEmployee, int>.DeleteAsync(int id)
        {
            var objToDelete = await ctx.ComEmployees.FindAsync(id);
            if (objToDelete == null) return null;
            ctx.ComEmployees.Remove(objToDelete);
            await ctx.SaveChangesAsync();
            return objToDelete;
        }

        async Task<IEnumerable<ComEmployee>> IService<ComEmployee, int>.GetAsync()
        {
            return await ctx.ComEmployees.ToListAsync();
        }

        async Task<ComEmployee> IService<ComEmployee, int>.GetAsync(int id)
        {
            return await ctx.ComEmployees.FindAsync(id);
        }

        async Task<ComEmployee> IService<ComEmployee, int>.UpdateAsync(int id, ComEmployee entity)
        {
            var objToUpate = await ctx.ComEmployees.FindAsync(id);
            if (objToUpate == null) return null;

            objToUpate.EmpName = entity.EmpName;
            objToUpate.Salary = entity.Salary;
            objToUpate.Designation = entity.Designation;
            objToUpate.Email = entity.Email;

            await ctx.SaveChangesAsync();
            return objToUpate;
        }
    }
}
