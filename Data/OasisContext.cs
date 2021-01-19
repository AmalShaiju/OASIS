using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OASIS.Models;
using Microsoft.AspNetCore.Http;
using System.Threading;

namespace OASIS.Data
{
    public class OasisContext : DbContext
    {
        //To give access to IHttpContextAccessor for Audit Data with IAuditable
        private IHttpContextAccessor _httpContextAccessor;

        public OasisContext(DbContextOptions<OasisContext> options)
        : base(options)
        {
            UserName = "SeedData";
        }

        //Property to hold the UserName value
        public string UserName
        {
            get; private set;
        }

        //To give access to IHttpContextAccessor for Audit Data with IAuditable
        public OasisContext(DbContextOptions<OasisContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            UserName = _httpContextAccessor.HttpContext?.User.Identity.Name;
            //UserName = (UserName == null) ? "Unknown" : UserName;
            UserName = UserName ?? "Unknown";
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is IAuditable trackable)
                {
                    var now = DateTime.UtcNow;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.UpdatedOn = now;
                            trackable.UpdatedBy = UserName;
                            break;

                        case EntityState.Added:
                            trackable.CreatedOn = now;
                            trackable.CreatedBy = UserName;
                            trackable.UpdatedOn = now;
                            trackable.UpdatedBy = UserName;
                            break;
                    }
                }
            }
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

            //Prevent Cascade Delete from Customer to Project
            //so we are prevented from deleting a customer with
            //project assigned
            modelBuilder.Entity<Customer>()
                .HasMany<Project>(d => d.Projects)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            // Name of the Role is Unique
            modelBuilder.Entity<Role>()
                .HasIndex(p => p.Name)
                .IsUnique();


            // Email of the Employee is Unique
            modelBuilder.Entity<Employee>()
                .HasIndex(p => p.Email)
                .IsUnique();


            // Name of the Customer is Unique
            modelBuilder.Entity<Customer>()
                .HasIndex(p => p.Email)
                .IsUnique();

            // Name of the Project is Unique
            modelBuilder.Entity<Project>()
                .HasIndex(p => p.Name)
                .IsUnique();
        }


        public DbSet<OASIS.Models.Project> Project { get; set; }


    }
    
}
