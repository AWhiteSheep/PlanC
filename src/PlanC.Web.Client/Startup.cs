using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanC.WebApi.Server.DataAccess;

namespace PlanC.Web.Client
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
            services.AddRazorPages();
            services.AddServerSideBlazor().AddCircuitOptions(configure => {
                configure.DetailedErrors = true;
            });
            services.AddControllersWithViews();

            // Ajout de la dbContext
            services.AddDbContext<PCU001Context>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("PCU001")));
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // Add the endpoint routing matcher middleware to the request pipeline
            app.UseRouting();
            app.UseHttpsRedirection();
            // For the wwroot folder
            app.UseStaticFiles();
            // Add the authorization middleware to the request pipeline
            app.UseAuthorization();
            // Add endpoints to the request pipeline
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub(option => {
                    option.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.LongPolling;                    
                });
                endpoints.MapFallbackToPage("/Index");
            });
        }
    }
}
