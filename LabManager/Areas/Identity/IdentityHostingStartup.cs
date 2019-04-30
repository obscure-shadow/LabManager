using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LabManager.Data;

[assembly: HostingStartup(typeof(LabManager.Areas.Identity.IdentityHostingStartup))]
namespace LabManager.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ApplicationDbContextConnection")));

                //NOTE: Try commenting out the line below to ehelp with Build.Run error:
                //services.AddDefaultIdentity<IdentityUser>()
                    //.AddEntityFrameworkStores<ApplicationDbContext>();
            });
        }
    }
}