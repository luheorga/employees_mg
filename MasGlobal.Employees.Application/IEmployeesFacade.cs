using System.Collections.Generic;
using System.Threading.Tasks;
using MasGlobal.Employees.Domain;

namespace MasGlobal.Employees.Application
{
    public interface IEmployeesFacade
    {
        Task<EmployeeInfo> GetEmployeeInfo(int id);
        Task<IEnumerable<EmployeeInfo>> GetEmployeesInfo();
    }
}