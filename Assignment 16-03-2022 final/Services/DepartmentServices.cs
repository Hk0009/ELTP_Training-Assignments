using Assignment_16_03_2022_final.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Assignment_16_03_2022_final.Services.IService;

namespace Assignment_16_03_2022_final.Services
{
    public class DepartmentServices : IService<Mydatabase,int>
    {

        private readonly MydatabaseContext ctx;

        //inject the DemoContext
        public DepartmentServices(MydatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        async Task<Mydatabase> IService<Mydatabase, int>.CreateAsync(Mydatabase entity)
        {
            var res = await ctx.Mydatabases.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        async Task<Mydatabase> IService<Mydatabase, int>.DeleteAsync(int id)
        {
            var objToDelete = await ctx.Mydatabases.FindAsync(id);
            if (objToDelete == null) return null;
            ctx.Mydatabases.Remove(objToDelete);
            await ctx.SaveChangesAsync();
            return objToDelete;
        }

        async Task<IEnumerable<Mydatabase>> IService<Mydatabase, int>.GetAsync()
        {

            return await ctx.Mydatabases.ToListAsync();


        }

        async Task<Mydatabase> IService<Mydatabase, int>.GetAsync(int id)
        {
            return await ctx.Mydatabases.FindAsync(id);
        }

        async Task<Mydatabase> IService<Mydatabase, int>.UpdateAsync(int id, Mydatabase entity)
        {
            var objToUpate = await ctx.Mydatabases.FindAsync(id);
            if (objToUpate == null) return null;

            objToUpate.DeptName = entity.DeptName;
            objToUpate.Location = entity.Location;
            objToUpate.Capctay = entity.Capctay;

            await ctx.SaveChangesAsync();
            return objToUpate;
        }

    }
}
