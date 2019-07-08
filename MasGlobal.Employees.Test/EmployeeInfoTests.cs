using MasGlobal.Employees.Data.Abstractions;
using MasGlobal.Employees.Domain;
using MasGlobal.Employees.Domain.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasGlobal.Employees.Test
{
    [TestClass]
    public class EmployeeInfoTests
    {
        [TestMethod]
        public void WhenRequestEmployeeInfo_ThenMustAddTheContratInfo_ShouldReturnEmployeeInfo()
        {
            Employee employee = new Employee
            {
                Id = 1,
                Name = "Luis",
                RoleId = 1,
                RoleDescription = "Software Developer",
                RoleName = "Software Developer",
                ContractTypeName = "MonthlySalaryEmployee",
                HourlySalary = 6000,
                MonthlySalary = 80000
            };

            IEmployeeContract contract = new MonthlyEmployeeContract(employee);

            EmployeeInfo employeeInfo = EmployeeInfo.GetEmployeeInfo(employee);

            Assert.AreEqual(contract.ConctratName, employeeInfo.ContratcName);
            Assert.AreEqual(contract.GetSalary(), employeeInfo.Salary);
            Assert.AreEqual(contract.GetAnnualSalary(), employeeInfo.AnnualSalary);
            Assert.AreEqual(1, employeeInfo.Id);
            Assert.AreEqual("Luis", employeeInfo.Name);
            Assert.AreEqual(1, employeeInfo.RoleId);
            Assert.AreEqual("Software Developer", employeeInfo.RoleDescription);
            Assert.AreEqual("Software Developer", employeeInfo.RoleName);
        }
    }
}