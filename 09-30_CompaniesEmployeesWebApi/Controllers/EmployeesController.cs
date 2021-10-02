using _09_30_CompaniesEmployeesWebApi.Dtos;
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
        public async Task<ActionResult<List<EmployeeGetDto>>> GetAll()
        {
            return Ok(await _employeesService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeGetDto>> Get(int id)
        {
            return Ok(await _employeesService.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Add(EmployeeAddUpdateDto employeeDto)
        {
            await _employeesService.AddAsync(employeeDto);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, EmployeeAddUpdateDto employeeDto)
        {
            await _employeesService.UpdateAsync(id, employeeDto);

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
