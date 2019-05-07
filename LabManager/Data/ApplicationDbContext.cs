using System;
using System.Collections.Generic;
using System.Text;
using LabManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LabManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //NOTE: Employee is ApplicationUser:
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<ChemicalType> ChemicalTypes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<LabThing> LabThing { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Chemical>().ToTable("Chemical");
            modelBuilder.Entity<ChemicalType>().ToTable("ChemicalType");
            modelBuilder.Entity<Manufacturer>().ToTable("Manufacturer");
            modelBuilder.Entity<LabThing>().ToTable("LabThing");

            base.OnModelCreating(modelBuilder);
        }

    }

}