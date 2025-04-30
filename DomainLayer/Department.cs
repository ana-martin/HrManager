using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }

        public Department(int departmentId, string departmentName, string location) 
        {
            DepartmentId = departmentId;
            DepartmentName = departmentName;
            Location = location;
        }
        public Department() { }

        [ForeignKey("EmployeeId")]
        public virtual ICollection<Employee> Employees { get; set; }

    }
}
