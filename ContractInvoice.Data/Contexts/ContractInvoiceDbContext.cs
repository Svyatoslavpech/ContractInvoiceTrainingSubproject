using ContractInvoice.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace ContractInvoice.Data.Contexts
{
    public class ContractInvoiceDbContext : IdentityDbContext<ContractInvoiceUser>
    {
        public object contractInvoiceUser;

        public ContractInvoiceDbContext(DbContextOptions options) : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Work> Work { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Project> Project { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<ContractInvoiceUser> ContractInvoiceUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Work>().ToTable("Work");

            modelBuilder.Entity<Project>().ToTable("Project");

            modelBuilder.Entity<ContractInvoiceUser>().ToTable("ContractInvoiceUser");

        }    
    }
}