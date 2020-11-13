using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GestionChevauxBlazor.Areas.Identity;
using GestionChevauxBlazor.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using GestionChevauxBlazor.Services;
using GestionChevauxBlazor.Models;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace GestionChevauxBlazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")),
                    ServiceLifetime.Transient
                );
            // services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            //{
            //    config.SignIn.RequireConfirmedEmail = true;
            //    config.Tokens.ProviderMap.Add("CustomEmailConfirmation",
            //        new TokenProviderDescriptor(
            //            typeof(CustomEmailConfirmationTokenProvider<IdentityUser>)));
            //    config.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
            //})
            //SG.VAJoszl5T - uT4X4J8iYZcg.9VD - uq37inRbAroSZJ3dcgz6sKmGR3k9jE4eJL - RnHw
            //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
            services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.SignIn.RequireConfirmedEmail = true;
                    options.Tokens.ProviderMap.Add("CustomEmailConfirmation",
                    new TokenProviderDescriptor(
                        typeof(CustomEmailConfirmationTokenProvider<IdentityUser>)));
                    options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
                })                
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();
            //services.AddDefaultIdentity<IdentityUser>(
            //    options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            // requires
            // using Microsoft.AspNetCore.Identity.UI.Services;
            // using WebPWrecover.Services;
            //services.AddTransient<CustomEmailConfirmationTokenProvider<IdentityUser>>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
            services.AddTransient<IAjoutChevauxService, AjoutChevauxService>();
            services.AddTransient<IAjoutProgrammeService, AjoutProgrammeService>();
            services.AddTransient<IValidationProgrammeService, ValidationProgrammeService>();
            //services.AddSingleton<WeatherForecastService>();
            services.AddHttpContextAccessor();

            services.ConfigureApplicationCookie(o => {
                o.ExpireTimeSpan = TimeSpan.FromDays(5);
                o.SlidingExpiration = true;
            });
            services.Configure<DataProtectionTokenProviderOptions>(o =>
                o.TokenLifespan = TimeSpan.FromHours(3));
            services.AddTransient<CustomEmailConfirmationTokenProvider<IdentityUser>>();            
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
                app.UseExceptionHandler("/Error");
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
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            var supportedCultures = new[]
            {
               new CultureInfo("fr-FR"),

            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("fr-FR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
        }
    }
}
