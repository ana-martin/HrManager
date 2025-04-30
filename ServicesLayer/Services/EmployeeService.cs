using AutoMapper;
using DomainLayer;
using RepositoryLayer.Repository;
using ServicesLayer.Dto;

namespace ServicesLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private Mapper _personMapper;

        private IGenericRepository<Employee> _employeeRepository;
        private IGenericRepository<Position> _positionRepository;
        private IGenericRepository<Department> _departmentRepository;

        public EmployeeService (IGenericRepository<Employee> employeeRepository, IGenericRepository<Position> positionRepository, IGenericRepository<Department> departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _positionRepository = positionRepository;
            _departmentRepository = departmentRepository;

            var _configEmployee = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDto>().ReverseMap());
            _personMapper = new Mapper(_configEmployee);        
        }

        public void CreateEmployee(int departmentId, int positionId, Employee employee)
        {
            var department = _departmentRepository.GetById(departmentId);
            var position = _positionRepository.GetById(positionId);

            employee.Department = department;
            employee.Position = new List<Position> { position };
            _employeeRepository.Create(employee);
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = GetEmployee(id);
            _employeeRepository.Remove(employee);
            _employeeRepository.Save();
        }

        public ICollection<Employee> GetAllEmployees()
        {
            var employees = _personMapper.Map<List<EmployeeDto>>(_employeeRepository.GetAll());
            /*-changed-*/
            return (ICollection<Employee>)employees;
        }

        public Employee GetEmployee(int id)
        {
            var employee = _personMapper.Map<Employee>(_employeeRepository.GetById(id));
            return employee;
        }

        public void UpdateEmployee(EmployeeDto employee)
        {
            var employeeMap = _personMapper.Map<Employee>(employee);
            _employeeRepository.Update(employeeMap);        
        }
    }
}
