namespace MasGlobal.Employees.Domain.Contract
{
    public interface IEmployeeContract
    {
        string ContractName { get; }
        decimal GetSalary();
        decimal GetAnnualSalary();
    }
}