using System.Collections.Generic;

namespace MasGlobal.Employees.Data.Abstractions
{
    public interface IEmployeesRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
    }
}