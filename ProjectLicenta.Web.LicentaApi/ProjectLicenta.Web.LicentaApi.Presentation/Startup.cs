using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using ServerVersion = Pomelo.EntityFrameworkCore.MySql.Storage.ServerVersion;
using Newtonsoft.Json;
using ProjectLicenta.Web.LicentaApi.Core.Interfaces;
using ProjectLicenta.Web.LicentaApi.Core.Services;
using ProjectLicenta.Web.LicentaApi.Core.Validators;
using ProjectLicenta.Web.LicentaApi.Infrastructure.Data;
using ProjectLicenta.Web.LicentaApi.Infrastructure.Repositories;

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
            services.AddControllers().ConfigureApiBehaviorOptions(options => { });
            
            services.AddScoped<IUtilizatorService, UtilizatorService>();
            services.AddScoped<IUtilizatorRepository, UtilizatorRepository>();
            services.AddSingleton<IUtilizatorValidator, UtilizatorValidator>();
            
            services.AddScoped<IAnuntService, AnuntService>();
            services.AddScoped<IAnuntRepository, AnuntRepository>();
            services.AddSingleton<IAnuntValidator, AnuntValidator>();

            services.AddScoped<ICautareService, CautareService>();
            services.AddScoped<ICautareRepository, CautareRepository>();
            services.AddSingleton<ICautareValidator, CautareValidator>();
            
            
            services.AddControllers().ConfigureApiBehaviorOptions(options => { }).AddNewtonsoftJson(t =>
            {
                t.SerializerSettings.MaxDepth = 128;
                t.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            
            services.AddDbContext<DataContext>(options =>
            {
                options.UseMySql("server=localhost;port=3306;database=Licenta;user=root;password=abcdefg1",
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
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}