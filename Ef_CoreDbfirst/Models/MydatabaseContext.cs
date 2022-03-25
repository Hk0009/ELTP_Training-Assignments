using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ef_CoreDbfirst.Models
{
    public partial class MydatabaseContext : DbContext
    {
        public MydatabaseContext()
        {
        }

        public MydatabaseContext(DbContextOptions<MydatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ComEmployee> ComEmployees { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DeptEmp> DeptEmps { get; set; } = null!;
        public virtual DbSet<EmployeeAdit> EmployeeAdits { get; set; } = null!;
        public virtual DbSet<Mydatabase> Mydatabases { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Mydatabase;Integrated Security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComEmployee>(entity =>
            {
                entity.HasKey(e => e.EmpNo)
                    .HasName("PK__ComEmplo__AF2D66D3E74D1445");

                entity.ToTable("ComEmployee");

                entity.Property(e => e.EmpNo).ValueGeneratedNever();

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.ComEmployees)
                    .HasForeignKey(d => d.DeptNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ComEmploy__DeptN__286302EC");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptNo)
                    .HasName("PK__Departme__0148CAAECFE326EB");

                entity.ToTable("Department");

                entity.Property(e => e.DeptNo).ValueGeneratedNever();

                entity.Property(e => e.DeptName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DeptEmp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DeptEmp");

                entity.Property(e => e.DeptName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeAdit>(entity =>
            {
                entity.HasKey(e => e.Auditid)
                    .HasName("PK__Employee__A17E27B0DF2F7B62");

                entity.ToTable("EmployeeAdit");

                entity.Property(e => e.AuditDate)
                    .HasColumnType("date")
                    .HasColumnName("auditDate");

                entity.Property(e => e.AuditEmpNo).HasColumnName("auditEmpNo");
            });

            modelBuilder.Entity<Mydatabase>(entity =>
            {
                entity.HasKey(e => e.DeptNo)
                    .HasName("PK__Mydataba__0148CAAE99599EA9");

                entity.ToTable("Mydatabase");

                entity.HasIndex(e => e.DeptName, "DeptName_Unique")
                    .IsUnique();

                entity.Property(e => e.DeptNo).ValueGeneratedNever();

                entity.Property(e => e.DeptName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
