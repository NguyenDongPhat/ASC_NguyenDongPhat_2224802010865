﻿using ASC.DataAccess;
using ASC.Solution.Services;
using ASC.Web.Configuration;
using ASC.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASC.Web.Services
{
    public static class DependencyInjection
    {
        //Config services
        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration config)
        {

            // Add AddDbContext with connectionString to mirage database
            var connectionString = config.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            //Add Options and get data from appsettings.json with "AppSettings"
            services.AddOptions();//IOption
            services.Configure<ApplicationSettings>(config.GetSection("AppSettings"));

            //Using a Gmail Authentication Provider for Customer Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                options.DefaultChallengeScheme = "Google"; // hoặc Cookie nếu bạn có nhiều provider
            })
                .AddCookie() // <- thêm dòng này nếu chưa có
                .AddGoogle(options =>
                {
                    IConfigurationSection googleAuthNSection = config.GetSection("Authentication:Google");
                    options.ClientId = config["Google:Identity:ClientId"];
                    options.ClientSecret = config["Google:Identity:ClientSecret"];
                });

            return services;
        }

        //Add service
        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services)
        {
            //Add ApplicationDbContext
            services.AddScoped<DbContext, ApplicationDbContext>();

            //Add IdentityUser IdentityUser
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            //Add services
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddSingleton<IIdentitySeed, IdentitySeed>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add Cache, Session
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDistributedMemoryCache(); // Add distributed cache
            services.AddSingleton<INavigationCacheOperations, NavigationCacheOperations>();

            //....

            //Add RazorPages, MVC
            services.AddRazorPages();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddControllersWithViews();

            return services;
        }
    }
}
