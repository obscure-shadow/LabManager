using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LabManager.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LabManager.Models;

namespace LabManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //==================================================================================================
            //NOTE: Dependency injection

            //services.AddDbContext<ApplicationDbContext>(options =>
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            //NOTE: Changed <IdentityUser> below to <Employee>
            services.AddDefaultIdentity<Employee>()
                //==================================================================================================

                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();


        //==================================================================================================

        //NOTE: This configures the route to allow the "home" page to become the login screen. When this block is commented out, the page loads the home screen at the "/Home" URL. The "LabManager" link and Chemicals/Lab Items links will redirect the user to the login screen if the user is not logged in. However, when this block is active, the login screen is the one that loads but the "LabManager" link in the navbar does not route to anything:
        services.AddMvc().AddRazorPagesOptions(options =>
            {
            options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        services.AddMvc()
            .AddRazorPagesOptions(options =>
            {
            //options.Conventions.AuthorizePage("/Home");
            // Added authorization to /Home/Index while trying to figure out how to route the home button to the Home/Index page rather than the login page:
            options.Conventions.AuthorizePage("/Home/Index");

        });
        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                //template: "{controller=Home}/{action=Home}/{id?}");

                //NOTE: start the user off with the login screen at URL: https://localhost:5001/Identity/Account/Login

                //NOTE: See the MVC routes services that was added to the config method above
                //routes.MapRoute(
                //        name: "accountlogin",
                //        template: "Identity",
                //        defaults: new { controller = "Account", action = "Login" });
            });
        }
    }
}
