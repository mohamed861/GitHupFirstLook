using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCD08Lab.Models;

namespace MVCD08Lab
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<CompanyContext>(opt=>opt.UseSqlServer(@"Server=DESKTOP-04URTDL\SQLEXPRESS;Database=MVCD08Lab.Models.CompanyContext;Trusted_Connection=true;"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                //endpoints.MapControllerRoute(
                //    name:"Default",
                //    pattern:"{controller}/{action}/{id}",
                //    defaults:new { controller="Employee",action="Index",id=UrlParameter.Optional}
                //    );
                endpoints.MapControllerRoute(
                    name: "def",
                    pattern: "{controller=Employee}/{action=index}/{id?}"
                    );
            });
        }
    }
}
