using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public int PositionId { get; set; }

        public Employee(int employeeId, string firstName, string lastName, string email, DateTime hireDate, int positionId) 
        { 
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            HireDate = hireDate;
            PositionId = positionId;
        }
        public Employee() { }

        [ForeignKey("PositionId")]
        public virtual ICollection<Position> Positions { get; set; }

        /*added after*/
        public Department Department { get; set; }
        public List<Position> Position { get; set; }
    }
}
