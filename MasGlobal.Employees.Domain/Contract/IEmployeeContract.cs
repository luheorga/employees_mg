namespace MasGlobal.Employees.Domain.Contract
{
    public interface IEmployeeContract
    {
        string ConctratName { get; }
        decimal GetSalary();
        decimal GetAnnualSalary();
    }
}