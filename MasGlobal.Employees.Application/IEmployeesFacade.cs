using System.Collections.Generic;
using MasGlobal.Employees.Domain;

namespace MasGlobal.Employees.Application
{
    public interface IEmployeesFacade
    {
        EmployeeInfo GetEmployeeInfo(int id);
        List<EmployeeInfo> GetEmployeesInfo();
    }
}