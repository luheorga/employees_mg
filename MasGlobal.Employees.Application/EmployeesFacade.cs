using System.Collections.Generic;
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

        public EmployeeInfo GetEmployeeInfo(int id)
        {
            Employee employee = _employeesRepository.GetEmployee(id);
            return _employeeInfoFacade.GetEmployeeInfo(employee);
        }

        public List<EmployeeInfo> GetEmployeesInfo()
        {
            List<Employee> employees = _employeesRepository.GetEmployees();
            return _employeeInfoFacade.GetEmployeesInfo(employees);
        }
    }
}
