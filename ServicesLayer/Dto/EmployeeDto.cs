namespace ServicesLayer.Dto
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public int PositionId { get; set; }
        //public int DepartmentId {  get; set; }

    }
}
