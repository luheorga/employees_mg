using System.Collections.Generic;
using MasGlobal.Employees.Data.Abstractions;

namespace MasGlobal.Employees.Domain
{
    public class EmployeeInfoFacade : IEmployeeInfoFacade
    {
        public EmployeeInfo GetEmployeeInfo(Employee employee)
        {
            return EmployeeInfo.GetEmployeeInfo(employee);
        }

        public List<EmployeeInfo> GetEmployeesInfo(List<Employee> employees)
        {
            return EmployeeInfo.GetEmployeesInfo(employees);
        }
    }
}