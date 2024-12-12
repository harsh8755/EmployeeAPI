using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EngineersDeskAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult GetEmployees()
        {
            try
            {
                var employees = _employeeRepository.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status416RequestedRangeNotSatisfiable, ex.Message);
            }

        }
        [HttpGet]
        public ActionResult GetEmployeesById(int Id)
        {
            try
            {
                var employee = _employeeRepository.GetEmployeeById(Id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status416RequestedRangeNotSatisfiable, ex.Message);
            }
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employees)
        {
            try
            {
                var Addemployees = _employeeRepository.AddEmployee(employees); 
                return Ok(Addemployees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status416RequestedRangeNotSatisfiable, ex.Message);
            }

        }
        [HttpPut]
        public ActionResult PutEmployee(int id, Employee employee)
        {
            try
            {
                var updatedEmployee = _employeeRepository.UpdateEmployee(id,employee);
                if (updatedEmployee == null)
                {
                    return NotFound("Employee not found.");
                }

                return Ok("Employee updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpDelete]
        public ActionResult DeleteEmployeeById(int Id)
        {
            try
            {
                var deleteEmployee = _employeeRepository.DeleteEmployee(Id);
                if (deleteEmployee != null)
                {
                    return Ok("Employee deleted successfully.");
                }
                else
                {
                    return BadRequest("Employee id not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status416RequestedRangeNotSatisfiable, ex.Message);
            }
        }

    }
}
