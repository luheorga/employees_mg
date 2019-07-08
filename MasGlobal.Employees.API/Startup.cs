﻿using MasGlobal.Employees.Resolver;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.DependencyInjection;

namespace MasGlobal.Employees.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonFormatters()
                .AddCors(options => options.AddPolicy("https", 
                    builder => builder.WithOrigins("https://localhost:5001")));

            services.AddEmployeeServices();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "App/dist";
            });
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("https");
            app.UseSpaStaticFiles();
            app.UseMvc();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "App";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
