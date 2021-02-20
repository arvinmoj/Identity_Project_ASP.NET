using Data;
using System;
using Repository;
using FluentValidation;
using Validator.Account;
using ViewModels.Account;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace My_Application
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
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                .AddFluentValidation();

            #region Fluent Validation
            services.AddTransient<IValidator<LoginViewModel>, LoginValidation>();
            services.AddTransient<IValidator<RegisterViewModel>, RegisterValidation>();
            #endregion

            #region DatabaseContext
            services.AddDbContext<DatabaseContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DatabaseContext")));
            #endregion

            #region Identity Setting
            // Identity Setting
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                #region User
                // Require Unique Email
                options.User.RequireUniqueEmail = true;
                // Allowed UserName Characters
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                #endregion

                #region SignIn
                // Require Confirmed Email
                options.SignIn.RequireConfirmedEmail = true;
                //Require Confirmed Account
                options.SignIn.RequireConfirmedAccount = false;
                // Require Confirmed PhoneNumber
                options.SignIn.RequireConfirmedPhoneNumber = false;
                #endregion

                #region Password
                // Required Length
                options.Password.RequiredLength = 8;
                // Require Digit
                options.Password.RequireDigit = true;
                // Required Unique Chars
                options.Password.RequiredUniqueChars = 0;
                // Require Uppercase
                options.Password.RequireUppercase = true;
                // Require Lowercase
                options.Password.RequireLowercase = true;
                // Require Non Alphanumeric
                options.Password.RequireNonAlphanumeric = true;
                #endregion

                #region LockOut
                // Allowed For NewUsers
                options.Lockout.AllowedForNewUsers = true;
                // Max Failed Access Attempts
                options.Lockout.MaxFailedAccessAttempts = 5;
                // Default Lockout TimeSpan
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                #endregion

            })
            #endregion
            
            // Token Error Message
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();

            // Message Sender
            services.AddScoped<IMessageSender, MessageSender>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}