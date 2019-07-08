using System.Collections.Generic;
using MasGlobal.Employees.Data.Abstractions;

namespace MasGlobal.Employees.Domain
{
    public interface IEmployeeInfoFacade
    {
        EmployeeInfo GetEmployeeInfo(Employee employee);
        IEnumerable<EmployeeInfo> GetEmployeesInfo(IEnumerable<Employee> employees);
    }
}