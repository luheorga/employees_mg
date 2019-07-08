using MassGlobal.Employees.Resolver;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MasGlobal.Employees.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters();
            services.AddEmployeeServices();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
