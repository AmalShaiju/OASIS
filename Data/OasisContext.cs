using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OASIS.Models;
namespace OASIS.Data
{
    public class OasisContext : DbContext
    {
        public OasisContext(DbContextOptions<OasisContext> options)
        : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("OA");

            //Prevent Cascade Delete from Role to Employee
            //so we are prevented from deleting a Role with
            //Employees assigned
            modelBuilder.Entity<Role>()
                .HasMany<Employee>(d => d.Employees)
                .WithOne(p => p.Role)
                .HasForeignKey(p => p.RoleID)
                .OnDelete(DeleteBehavior.Restrict);
        }


        public DbSet<OASIS.Models.Role> Role { get; set; }
    }
    
}
