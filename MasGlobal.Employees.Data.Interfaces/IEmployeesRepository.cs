using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobal.Employees.Data.Abstractions
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
    }
}