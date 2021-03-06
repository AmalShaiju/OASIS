using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using OASIS.Data;
using OASIS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static OASIS.Utilities.EmailService;

namespace OASIS
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

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/UserRoles/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddDbContext<OasisContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("OasisContext")));
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            //For email service
            services.AddSingleton<IEmailConfiguration>(Configuration
                .GetSection("EmailConfiguration").Get<EmailConfiguration>());

            //For the Identity System
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("EmployeeViewPolicy", policy => policy.RequireClaim("EmployeeViewClaim", "True"));
                options.AddPolicy("EmployeeCreatePolicy", policy => policy.RequireClaim("EmployeeCreateClaim", "True"));
                options.AddPolicy("EmployeeEditPolicy", policy => policy.RequireClaim("EmployeeEditClaim", "True"));

                options.AddPolicy("CustomerViewPolicy", policy => policy.RequireClaim("CustomerViewClaim", "True"));
                options.AddPolicy("CustomerCreatePolicy", policy => policy.RequireClaim("CustomerCreateClaim", "True"));
                options.AddPolicy("CustomerEditPolicy", policy => policy.RequireClaim("CustomerEditClaim", "True"));

                options.AddPolicy("ProjectViewPolicy", policy => policy.RequireClaim("ProjectViewClaim", "True"));
                options.AddPolicy("ProjectEditPolicy", policy => policy.RequireClaim("ProjectEditClaim", "True"));
                options.AddPolicy("ProjectCreatePolicy", policy => policy.RequireClaim("ProjectCreateClaim", "True"));

                options.AddPolicy("BidViewPolicy", policy => policy.RequireClaim("BidViewClaim", "True"));
                options.AddPolicy("BidEditPolicy", policy => policy.RequireClaim("BidEditClaim", "True"));
                options.AddPolicy("BidCreatePolicy", policy => policy.RequireClaim("BidCreateClaim", "True"));

                options.AddPolicy("ProductViewPolicy", policy => policy.RequireClaim("ProductViewClaim", "True"));
                options.AddPolicy("ProductCreatePolicy", policy => policy.RequireClaim("ProductCreateClaim", "True"));
                options.AddPolicy("ProductEditPolicy", policy => policy.RequireClaim("ProductEditClaim", "True"));

                options.AddPolicy("UserRolesViewPolicy", policy => policy.RequireClaim("UserRolesViewClaim", "True"));


            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
