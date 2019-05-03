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
        public DbSet<LabThing> LabThings { get; set; }
        //public DbSet<LabThing> LabThings { get; set; }
        //NOTE: DbSet for LabThing was created in the Data/LabManagerContext.cs when the LabManager Controller was scaffolded.

        //NOTE: Confirm whether this is necessary (compare to BangazonSite project):
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //public void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

    }

}