using System.Collections.Generic;
using System.Threading.Tasks;
using MasGlobal.Employees.Application;
using MasGlobal.Employees.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MasGlobal.Employees.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesFacade _employeesFacade;

        public EmployeesController(IEmployeesFacade employeesFacade)
        {
            _employeesFacade = employeesFacade;
        }

        [HttpGet("{id}")]
        public Task<EmployeeInfo> GetEmployeeInfo(int id)
        {
            return _employeesFacade.GetEmployeeInfo(id);
        }

        [HttpGet]
        public Task<IEnumerable<EmployeeInfo>> GetEmployeesInfo()
        {
            return _employeesFacade.GetEmployeesInfo();
        }
    }
}