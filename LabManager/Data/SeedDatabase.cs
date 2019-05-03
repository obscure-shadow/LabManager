using LabManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabManager.Data
{
    public class SeedDatabase
    {
        public static void Initialize(ApplicationDbContext context)
        {

            //======================================================================
            //NOTE: Seeds the database with Categories
            context.Database.EnsureCreated();

            if (context.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category{Name="Instruments"},
                new Category{Name="Supplies"},
                new Category{Name="Equipment"},
                new Category{Name="Other"}
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();
            //======================================================================

            //NOTE: Seeds the database with ChemicalTypes

            context.Database.EnsureCreated();

            if (context.ChemicalTypes.Any())
            {
                return;
            }

            var chemicalType = new ChemicalType[]
            {
                new ChemicalType{Name="Reagent"},
                new ChemicalType{Name="Standard"},
                new ChemicalType{Name="Other"}
            };
            foreach (ChemicalType ct in chemicalType)
            {
                context.ChemicalTypes.Add(ct);
            }
            context.SaveChanges();

            //======================================================================

            //NOTE: Seeds the database with Manufacturers

            context.Database.EnsureCreated();

            if (context.Manufacturers.Any())
            {
                return;
            }

            var manufacturer = new Manufacturer[]
            {
                new Manufacturer{Name="AccuStandard"},
                new Manufacturer{Name="Bio-Rad"},
                new Manufacturer{Name="Cerilliant"},
                new Manufacturer{Name="Cole Parmer"},
                new Manufacturer{Name="Control Company"},
                new Manufacturer{Name="Daigger Scientific"},
                new Manufacturer{Name="FisherSci"},
                new Manufacturer{Name="GFS Chemicals"},
                new Manufacturer{Name="Grainger"},
                new Manufacturer{Name="High-Purity Standards"},
                new Manufacturer{Name="Honeywell"},
                new Manufacturer{Name="Labnet International"},
                new Manufacturer{Name="Luminex"},
                new Manufacturer{Name="McKesson"},
                new Manufacturer{Name="Medline"},
                new Manufacturer{Name="Midland Scientific"},
                new Manufacturer{Name="MilliporeSigma"},
                new Manufacturer{Name="Molecular Devices"},
                new Manufacturer{Name="Novatech"},
                new Manufacturer{Name="Promega"},
                new Manufacturer{Name="QIAGEN"},
                new Manufacturer{Name="Sciex"},
                new Manufacturer{Name="SigmaAldrich"},
                new Manufacturer{Name="ThermoFisher"},
                new Manufacturer{Name="Witton"}

            };
            foreach (Manufacturer m in manufacturer)
            {
                context.Manufacturers.Add(m);
            }
            context.SaveChanges();

            //======================================================================

            //NOTE: Seeds the database with Employees


            //FROM BANGAZON:
            //ApplicationUser user = new ApplicationUser
            //{
            //    FirstName = "admin",
            //    LastName = "admin",
            //    StreetAddress = "123 Infinity Way",
            //    UserName = "admin@admin.com",
            //    NormalizedUserName = "ADMIN@ADMIN.COM",
            //    Email = "admin@admin.com",
            //    NormalizedEmail = "ADMIN@ADMIN.COM",
            //    EmailConfirmed = true,
            //    LockoutEnabled = false,
            //    SecurityStamp = Guid.NewGuid().ToString("D")
            //};
            //var passwordHash = new PasswordHasher<ApplicationUser>();
            //user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            //modelBuilder.Entity<ApplicationUser>().HasData(user);
            //======================================================================
            // Modified employee:

            context.Database.EnsureCreated();

            if (context.Employees.Any())
            {
                return;
            }

            var employees = new List<Employee>();

            Employee employee = new Employee
            {
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash = new PasswordHasher<Employee>();
            employee.PasswordHash = passwordHash.HashPassword(employee, "Admin8*");

            employees.Add(employee);

            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();

            //======================================================================
            //NOTE: My original create employee:

            //context.Database.EnsureCreated();

            //if (context.Employees.Any())
            //{
            //    return;
            //}

            //var employees = new Employee[]
            //{
            //    new Employee{FirstName="Patricia", LastName="Spinelli", HireDate=DateTime.Parse("2006-03-15")},
            //    new Employee{FirstName="Bert", LastName="Bolderdash", HireDate=DateTime.Parse("2013-07-08")},
            //    new Employee{FirstName="Bunbury", LastName="Bunbury", HireDate=DateTime.Parse("2018-09-23")}
            //};
            //foreach (Employee e in employees)
            //{
            //    context.Employees.Add(e);
            //}
            //context.SaveChanges();

            //======================================================================

            //NOTE: Seeds the database with LabThings

            context.Database.EnsureCreated();

            if (context.LabThings.Any())
            {
                return;
            }

            var labThing = new LabThing[]
            {
                new LabThing{Name="Pipette", SerialNo="ABC12345NRX", ModelNo="1980", AcquisitionDate=DateTime.Parse("2001-01-01"), CalibratedOn=DateTime.Parse("2019-02-01"), CalibrationDue=DateTime.Parse("2020-02-01"), MaintenanceOn=DateTime.Parse("2019-02-01"), MaintenanceDue=DateTime.Parse("2020-02-01"), Note="N/A", EmployeeId="1", CategoryID=3, ManufacturerID=7},
                new LabThing { Name = "Spectrometric Analyzer", SerialNo = "SN48206874", ModelNo = "AB24509", AcquisitionDate = DateTime.Parse("2015-07-09"), CalibratedOn = DateTime.Parse("2019-04-16"), CalibrationDue = DateTime.Parse("2019-05-16"), MaintenanceOn = DateTime.Parse("2019-01-01"), MaintenanceDue = DateTime.Parse("2020-01-01"), Note = "N/A", EmployeeId ="2", CategoryID =1, ManufacturerID =22}
    };
            foreach (LabThing lt in labThing)
            {
                context.LabThings.Add(lt);
            }
            context.SaveChanges();


        }
    }
}
