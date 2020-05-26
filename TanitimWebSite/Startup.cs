using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TanitimWebSite
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
            //Mvc aktif et ve routeconfig eklenebilmesi için routing false yapýlý
            services.AddMvc(x => x.EnableEndpointRouting = false);
            //Deðiþikliklerde sayfanýn güncellenebilmesi için
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //statik dosyalarýn çalýþabilmesi için via:wwwroot
            app.UseStaticFiles();
            //defauklt route deðerlerini{Controller}/{action}/{id}
            app.UseMvcWithDefaultRoute();
        }
    }
}
