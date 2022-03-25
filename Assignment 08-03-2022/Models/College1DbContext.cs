using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assignment_08_03_2022.Models
{
    public class College1DbContext : DbContext
    {

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public College1DbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=College;Integrated Security=SSPI");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasOne(c => c.Course) // One-To-One
                        .WithMany(p => p.Students) // One-To-Many
                        .HasForeignKey(p => p.CourseId); // FOreign Key
            base.OnModelCreating(modelBuilder);

        }
    }
}
