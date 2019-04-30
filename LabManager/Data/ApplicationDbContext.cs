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
        //NOTE: LabThing and Chemical have Category, Manufacturer, and ChemicalType referenced as FKs. There is no need to add a DbSet for them here because LabThing and Chemical reference them.
        public DbSet<LabThing> LabThings {get; set;}
        public DbSet<Chemical> Chemicals {get; set;}

    }
}
