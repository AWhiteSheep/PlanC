using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ganss.XSS; // package pour la protection des attack xss
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanC.Client.Data;
using PlanC.EntityDataModel;
using AspNetCore.RouteAnalyzer; // package pour analyser les routes
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Ajout de la dbContext
            services.AddDbContext<PCU001Context>(options => 
                options.UseSqlServer("Data Source=database-1.cai5lbxs9ofy.us-east-1.rds.amazonaws.com,1433;User ID=dbo802668235;Password=Nemesis2123%*;Initial Catalog=PCU001;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

            // ajout du identity store et provider
                services.AddDefaultIdentity<Utilisateurs>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<PCU001Context>().AddDefaultUI()
                .AddDefaultTokenProviders();


            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Compte/Login";
                options.LogoutPath = $"/Compte/Logout";
                options.AccessDeniedPath = $"/Compte/AccessDenied";
            });

            services.AddServerSideBlazor();
            services.AddRazorPages();
            services.AddMvc();

            // ajoute l'analyseur des routes
            services.AddRouteAnalyzer(); 

            services.AddCors();

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            Microsoft.Extensions.Hosting.IHostApplicationLifetime applicationLifetime, IRouteAnalyzer routeAnalyzer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
                app.UseBrowserLink();
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

            app.UseCors(o => o.AllowAnyOrigin()
                .AllowAnyHeader().AllowAnyMethod());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub(option => {
                    option.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.LongPolling;
                });
                endpoints.MapFallbackToPage("/_Host");
            });

            
            applicationLifetime.ApplicationStarted.Register(() =>
            {
                var infos = routeAnalyzer.GetType().GetField("m_actionDescriptorCollectionProvider",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(routeAnalyzer);
                foreach (var info in ((ActionDescriptorCollection)infos.GetType().GetProperty("ActionDescriptors").GetValue(infos)).Items)
                {
                    Debug.WriteLine(info);
                }
                Debug.WriteLine("");
                Debug.WriteLine("");
            });
        }
    }
}
