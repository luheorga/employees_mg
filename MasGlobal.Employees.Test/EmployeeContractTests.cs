using System;
using MasGlobal.Employees.Data.Abstractions;
using MasGlobal.Employees.Domain.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasGlobal.Employees.Test
{
    [TestClass]
    public class EmployeeContractTests
    {
        [TestMethod]
        public void WhenEmployeeContractTypeIsMonthly_ThenShouldCalculateAnnualSalaryBasedOnMonths()
        {
            Employee employee = new Employee
            {
                ContractTypeName = "MonthlySalaryEmployee",
                HourlySalary = 6000,
                MonthlySalary = 80000
            };

            IEmployeeContract employeeContract = EmployeeContractFactory.GetEmployeeContract(employee);

            Assert.AreEqual(80000, employeeContract.GetSalary());
            Assert.AreEqual(960000, employeeContract.GetAnnualSalary());
        }

        [TestMethod]
        public void WhenEmployeeContractTypeIsHourly_ThenShouldCalculateAnnualSalaryBasedOnHours()
        {
            Employee employee = new Employee
            {
                ContractTypeName = "HourlySalaryEmployee",
                HourlySalary = 6000,
                MonthlySalary = 80000
            };

            IEmployeeContract employeeContract = EmployeeContractFactory.GetEmployeeContract(employee);

            Assert.AreEqual(6000, employeeContract.GetSalary());
            Assert.AreEqual(8640000, employeeContract.GetAnnualSalary());
        }

        [TestMethod]
        public void WhenEmployeeContractTypeIsUnknow_ThenShouldThowException()
        {
            Employee employee = new Employee
            {
                ContractTypeName = "UnknowSalaryEmployeee"
            };

            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => EmployeeContractFactory.GetEmployeeContract(employee));
        }
    }
}
