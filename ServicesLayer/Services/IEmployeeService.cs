using DomainLayer;
using ServicesLayer.Dto;

namespace ServicesLayer.Services
{
    public interface IEmployeeService
    {
        ICollection<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        void CreateEmployee(int departmentId, int positionId, Employee employee);
        void UpdateEmployee(EmployeeDto employee);
        void DeleteEmployee(int id);
    }
}
