using _09_30_CompaniesEmployeesWebApi.Dtos;
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
        public async Task<ActionResult<List<CompanyGetDto>>> GetAll()
        {
            return Ok(await _companiesService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyGetDto>> Get(int id)
        {
            return Ok(await _companiesService.GetAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Add(CompanyAddUpdateDto companyDto)
        {
            await _companiesService.AddAsync(companyDto);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CompanyAddUpdateDto companyDto)
        {
            await _companiesService.UpdateAsync(id, companyDto);

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
