using System;
using MasGlobal.Employees.Data.Abstractions;

namespace MasGlobal.Employees.Domain.Contract
{
    public class EmployeeContractFactory
    {
        public static IEmployeeContract GetEmployeeContract(Employee employee)
        {
            switch (employee.ContractTypeName)
            {
                case "HourlySalaryEmployee":
                    return new HourlyEmployeeContract(employee);
                case "MonthlySalaryEmployee":
                    return new MonthlyEmployeeContract(employee);
                default:
                    throw new ArgumentOutOfRangeException(nameof(employee.ContractTypeName));
            }
        }
    }
}