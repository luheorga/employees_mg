using System.Collections.Generic;
using MasGlobal.Employees.Data.Abstractions;

namespace MasGlobal.Employees.Domain
{
    public interface IEmployeeInfoFacade
    {
        EmployeeInfo GetEmployeeInfo(Employee employee);
        List<EmployeeInfo> GetEmployeesInfo(List<Employee> employees);
    }
}