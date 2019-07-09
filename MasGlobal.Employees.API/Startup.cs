using System.ComponentModel.DataAnnotations;
using MasGlobal.Employees.Configuration;
using MasGlobal.Employees.Resolver;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MasGlobal.Employees.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.Configure<CorsPolicyConfiguration>(_configuration.GetSection(nameof(CorsPolicyConfiguration)));

            services.Configure<ApiConfiguration>(_configuration);

            services.AddMvcCore()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonFormatters()
                .AddCors();

            services.AddEmployeeServices();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "App/dist";
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptionsMonitor<CorsPolicyConfiguration> optionsMonitor)
        {
            string[] allowedHosts = optionsMonitor.CurrentValue.AllowedHosts;
            app.UseCors(builder =>
            {
                builder.WithOrigins(allowedHosts)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
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
