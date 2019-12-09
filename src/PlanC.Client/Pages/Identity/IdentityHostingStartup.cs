using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlanC.Client.Data;
using PlanC.EntityDataModel;

[assembly: HostingStartup(typeof(PlanC.Client.Pages.Identity.Pages.IdentityHostingStartup))]
namespace PlanC.Client.Pages.Identity.Pages
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}