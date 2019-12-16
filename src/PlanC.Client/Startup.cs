using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlanC.Client.Data;
using Microsoft.EntityFrameworkCore;
using Ganss.XSS;
using Microsoft.Extensions.Hosting;
using PlanC.EntityDataModel;
using AspNetCore.RouteAnalyzer; // package pour analyser les routes
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PlanC.Client.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace PlanC.Client
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

            // Ajout de la dbContext
            services.AddDbContext<PCU001Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RDS_PCU001")));
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddAzureAd(options => Configuration.Bind("AzureAd", options))
            .AddCookie();

            services.AddAuthorization(options => {
                options.AddPolicy("AuthorizationNemesisGroupPolicy", policyBuilder =>
                policyBuilder.RequireClaim("groups",
                Configuration.GetValue<string>("AzureADGroup:AuthorizeAuthorizationNemesisGroupId")));
            });     

            // Be Safe – Sanitize Your HTML 
            services.AddScoped<IHtmlSanitizer, HtmlSanitizer>(x =>
            {
                // https://blog.jonblankenship.com/2019/01/27/safely-rendering-markdown-in-blazor/
                // Configure sanitizer rules as needed here.
                // For now, just use default rules + allow class attributes
                var sanitizer = new Ganss.XSS.HtmlSanitizer();
                sanitizer.AllowedAttributes.ToList().AddRange(new List<string> { "b", "ul", "ol", "li", "p","i", "u", "em", "strong",
                 "h1","h2","h3","h4","h5","h6","br","hr","blockquote","code", "del", "dl", "dd", "img", "pre", "s", "sup", "sub", "strike",
                "div"});
                return sanitizer;
            });
            services.AddCors();
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

            app.UseCors(o => o.AllowAnyOrigin()
                .AllowAnyHeader().AllowAnyMethod());

            app.UseHttpsRedirection();

            // ajoute le static files plus les default file et browser le directory
            app.UseStaticFiles();

            app.UseAuthorization();
            // identity authentication
            app.UseAuthentication();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                //endpoints.MapBlazorHub(option => {
                //    option.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.LongPolling;
                //});
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
