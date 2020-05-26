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
            //Mvc aktif et ve routeconfig eklenebilmesi i�in routing false yap�l�
            services.AddMvc(x => x.EnableEndpointRouting = false);
            //De�i�ikliklerde sayfan�n g�ncellenebilmesi i�in
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //statik dosyalar�n �al��abilmesi i�in via:wwwroot
            app.UseStaticFiles();
            //defauklt route de�erlerini{Controller}/{action}/{id}
            app.UseMvcWithDefaultRoute();
        }
    }
}
