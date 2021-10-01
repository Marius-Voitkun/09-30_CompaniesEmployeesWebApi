using _09_30_CompaniesEmployeesWebApi.Models;
using _09_30_CompaniesEmployeesWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _09_30_CompaniesEmployeesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly CompaniesService _companiesService;

        public CompaniesController(CompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> GetAll()
        {
            return Ok(await _companiesService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            return Ok(await _companiesService.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Add(Company company)
        {
            await _companiesService.AddAsync(company);

            return CreatedAtAction(nameof(Get), new { id = company.Id }, company);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Company company)
        {
            await _companiesService.UpdateAsync(company);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _companiesService.DeleteAsync(id);

            return NoContent();
        }
    }
}
