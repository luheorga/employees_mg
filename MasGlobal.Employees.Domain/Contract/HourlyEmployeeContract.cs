namespace MasGlobal.Employees.Domain.Contract
{
    public class HourlyEmployeeContract : IEmployeeContract
    {
        private readonly Employee _employee;

        public HourlyEmployeeContract(Employee employee)
        {
            _employee = employee;
        }

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