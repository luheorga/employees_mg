using System.ComponentModel.DataAnnotations;

namespace MasGlobal.Employees.Configuration
{
    public class ApiConfiguration
    {
        [Required(AllowEmptyStrings = false)]
        public string EmployeeApiUrl { get; set; }
    }
}