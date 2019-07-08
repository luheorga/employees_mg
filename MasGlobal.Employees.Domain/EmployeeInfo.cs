using System;
using System.Collections.Generic;
using System.Linq;
using MasGlobal.Employees.Data.Abstractions;
using MasGlobal.Employees.Domain.Contract;

namespace MasGlobal.Employees.Domain
{
    public class EmployeeInfo
    {
        private readonly Employee _employee;
        private readonly IEmployeeContract _employeeContract;

        private EmployeeInfo(Employee employee)
        {
            if (employee is null)
                throw new ArgumentNullException(nameof(employee));
            _employeeContract = EmployeeContractFactory.GetEmployeeContract(employee);
            _employee = employee;
        }

        public int Id => _employee.Id;
        public string Name => _employee.Name;
        public int RoleId => _employee.RoleId;
        public string RoleName => _employee.RoleName;
        public string RoleDescription => _employee.RoleDescription;
        public string ContratcName => _employeeContract.ConctratName;
        public decimal Salary => _employeeContract.GetSalary();
        public decimal AnnualSalary => _employeeContract.GetAnnualSalary();

        public static EmployeeInfo GetEmployeeInfo(Employee employee)
        {
            return new EmployeeInfo(employee);
        }

        public static List<EmployeeInfo> GetEmployeesInfo(List<Employee> employees)
        {
            return employees.Select(GetEmployeeInfo).ToList();
        }
    }
}