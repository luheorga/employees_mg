using MasGlobal.Employees.Application;
using MasGlobal.Employees.Data;
using MasGlobal.Employees.Data.Abstractions;
using MasGlobal.Employees.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace MassGlobal.Employees.Resolver
{
    public static class EmployeesServiceExtensions
    {
        public static IServiceCollection AddEmployeeServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHttpClient();
            serviceCollection.AddScoped<IEmployeesRepository, EmployeesAPIRepository>();
            serviceCollection.AddSingleton<IEmployeeInfoFacade, EmployeeInfoFacade>();
            serviceCollection.AddScoped<IEmployeesFacade, EmployeesFacade>();
            return serviceCollection;
        }

    }
}
