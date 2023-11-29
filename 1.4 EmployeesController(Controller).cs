using EmployeeCRUDAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmployeesController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        //API/EMPLOYEE
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _employeeDbContext.Employees.ToListAsync();
        }

        //API/EMPLOYEE/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeDbContext.Employees.FindAsync(id);

            if(employee == null)
            { 
                return NotFound(); 
            }
            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _employeeDbContext.Employees.Add(employee);    //function to add new employee to the Employees List
            await _employeeDbContext.SaveChangesAsync();   //updating the addition made to the Employees List

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id},employee); //returns HTTP satatus 201 , creates a new Location Header.
        }

       // [HttpPut]


       // [HttpDelete]
    }
}
