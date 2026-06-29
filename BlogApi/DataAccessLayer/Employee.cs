using System.ComponentModel.DataAnnotations;

namespace BlogApi.DataAccessLayer
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
    }
}
