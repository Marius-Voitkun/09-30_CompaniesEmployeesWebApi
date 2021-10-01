using _09_30_CompaniesEmployeesWebApi.Models;
using _09_30_CompaniesEmployeesWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _09_30_CompaniesEmployeesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesService _employeesService;

        public EmployeesController(EmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            return Ok(await _employeesService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            return Ok(await _employeesService.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Add(Employee employee)
        {
            await _employeesService.AddAsync(employee);

            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Employee employee)
        {
            await _employeesService.UpdateAsync(employee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _employeesService.DeleteAsync(id);

            return NoContent();
        }
    }
}
