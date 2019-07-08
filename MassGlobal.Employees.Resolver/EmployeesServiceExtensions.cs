using MasGlobal.Employees.Application;
using MasGlobal.Employees.Data.Abstractions;
using MasGlobal.Employees.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace MassGlobal.Employees.Resolver
{
    public static class EmployeesServiceExtensions
    {
        public static IServiceCollection AddEmployeServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IEmployeesRepository>();
            serviceCollection.AddSingleton<IEmployeeInfoFacade, EmployeeInfoFacade>();
            serviceCollection.AddScoped<IEmployeesFacade, EmployeesFacade>();
            return serviceCollection;
        }

    }
}
