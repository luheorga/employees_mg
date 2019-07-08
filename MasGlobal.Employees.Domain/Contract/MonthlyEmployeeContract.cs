using MasGlobal.Employees.Data.Abstractions;

namespace MasGlobal.Employees.Domain.Contract
{
    public class MonthlyEmployeeContract : IEmployeeContract
    {
        private readonly Employee _employee;

        public MonthlyEmployeeContract(Employee employee)
        {
            _employee = employee;
        }

        public string ContractName => "Monthly";

        public decimal GetSalary()
        {
            return _employee.MonthlySalary;
        }

        public decimal GetAnnualSalary()
        {
            return _employee.MonthlySalary * 12;
        }
    }
}