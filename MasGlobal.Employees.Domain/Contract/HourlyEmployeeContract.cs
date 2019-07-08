using MasGlobal.Employees.Data.Abstractions;

namespace MasGlobal.Employees.Domain.Contract
{
    public class HourlyEmployeeContract : IEmployeeContract
    {
        private readonly Employee _employee;

        public HourlyEmployeeContract(Employee employee)
        {
            _employee = employee;
        }

        public string ContractName => "Hourly";

        public decimal GetSalary()
        {
            return _employee.HourlySalary;
        }

        public decimal GetAnnualSalary()
        {
            return _employee.HourlySalary * 1440;
        }
    }
}