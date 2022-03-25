using Assignment_16_03_2022_final.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Assignment_16_03_2022_final.Services.IService;
namespace Assignment_16_03_2022_final.Services
{
    public class User : IService<User1,int>
    {
        private readonly MydatabaseContext ctx;

        //inject the DemoContext
        public User(MydatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        async Task<User1> IService<User1, int>.CreateAsync(User1 entity)
        {
            var res = await ctx.User1s.AddAsync(entity);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        async Task<User1> IService<User1, int>.DeleteAsync(int id)
        {
            var objToDelete = await ctx.User1s.FindAsync(id);
            if (objToDelete == null) return null;
            ctx.User1s.Remove(objToDelete);
            await ctx.SaveChangesAsync();
            return objToDelete;
        }

        async Task<IEnumerable<User1>> IService<User1, int>.GetAsync()
        {
            return await ctx.User1s.ToListAsync();
        }

        async Task<User1> IService<User1, int>.GetAsync(int id)
        {
            return await ctx.User1s.FindAsync(id);
        }

        async Task<User1> IService<User1, int>.UpdateAsync(int id, User1 entity)
        {
            var objToUpate = await ctx.User1s.FindAsync(id);
            if (objToUpate == null) return null;

            objToUpate.UserId = entity.UserId;
            objToUpate.UserName = entity.UserName;
            objToUpate.Pass = entity.Pass;

            await ctx.SaveChangesAsync();
            return objToUpate;
        }


    }
}
