using AutoMapper;
using DomainLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Dto;
using ServicesLayer.Services;

namespace HrManagerApi.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;         
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Employee))]
        public IActionResult GetEmployee(int id) 
        { 
            var result = _employeeService.GetEmployee(id);
            return Ok(result);
        }


        [HttpGet]
        [Route("/[controller]/[action]")]
        [ProducesResponseType(200, Type = typeof(ICollection<Employee>))]
        public IActionResult GetAllEmployees()
        {
            var result = _employeeService.GetAllEmployees();
            return Ok(result);
        }

        [HttpPost]
        [Route("/[controller]/[action]")]
        public IActionResult CreateEmployee([FromQuery] int departmentId, [FromQuery] int positionId, EmployeeDto employeeCreated) 
        {
            if (employeeCreated == null)          
                return BadRequest(ModelState);

            var employee = _employeeService.GetAllEmployees().Where(s => s.Email.Trim().ToLower() == employeeCreated.Email.Trim().ToLower())
                            .FirstOrDefault();

            if (employee != null) 
            {
                ModelState.AddModelError("", "Angajatul deja există");
                return StatusCode(422, ModelState);
            }

            var employeeMap = _mapper.Map<Employee>(employeeCreated);

            _employeeService.CreateEmployee(departmentId, positionId, employeeMap);

            return Ok("Angajat creat");
        }

        [HttpPatch]
        public IActionResult UpdateEmployee(EmployeeDto employee)
        {
            _employeeService.UpdateEmployee(employee);
            return Ok("Datele angajatului au fost modificate");
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id) 
        {
            _employeeService.DeleteEmployee(id);
            return Ok("Angajat șters");
        }

    }
}
