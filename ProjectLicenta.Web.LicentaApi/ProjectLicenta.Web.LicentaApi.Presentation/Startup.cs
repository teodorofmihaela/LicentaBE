using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using ServerVersion = Pomelo.EntityFrameworkCore.MySql.Storage.ServerVersion;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectLicenta.Web.LicentaApi.Infrastructure.Data;

namespace ProjectLicenta.Web.LicentaApi.Presentation
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                    builderOptions =>
                    {
                        builderOptions.MigrationsAssembly("ProjectLicenta.Web.LicentaApi.Presentation")
                            .ServerVersion(new ServerVersion(new Version(5, 7, 12)))
                            .CharSet(CharSet.Latin1);
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}