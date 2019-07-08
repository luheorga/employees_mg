using System.Collections.Generic;
using System.Threading.Tasks;
using MasGlobal.Employees.Data.Abstractions;
using MasGlobal.Employees.Domain;

namespace MasGlobal.Employees.Application
{
    public class EmployeesFacade : IEmployeesFacade
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IEmployeeInfoFacade _employeeInfoFacade;

        public EmployeesFacade(IEmployeesRepository employeesRepository, IEmployeeInfoFacade employeeInfoFacade)
        {
            _employeesRepository = employeesRepository;
            _employeeInfoFacade = employeeInfoFacade;
        }

        public async Task<EmployeeInfo> GetEmployeeInfo(int id)
        {
            Employee employee = await _employeesRepository.GetEmployee(id);
            return _employeeInfoFacade.GetEmployeeInfo(employee);
        }

        public async Task<IEnumerable<EmployeeInfo>> GetEmployeesInfo()
        {
            IEnumerable<Employee> employees = await _employeesRepository.GetEmployees();
            return _employeeInfoFacade.GetEmployeesInfo(employees);
        }
    }
}
