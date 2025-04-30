using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer
{
    public class Position
    {
        public int PositionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal SalaryRange { get; set; }
        public string Currency { get; set; }

        public Position(int positionId, string title, string description, decimal salaryRange, string currency) 
        {
            PositionId = positionId;
            Title = title;
            Description = description;
            SalaryRange = salaryRange;
            Currency = currency;
        }

        public Position() { }

        [ForeignKey("EmployeeId")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
