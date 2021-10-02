using _09_30_CompaniesEmployeesWebApi.DAL;
using _09_30_CompaniesEmployeesWebApi.Dtos;
using _09_30_CompaniesEmployeesWebApi.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _09_30_CompaniesEmployeesWebApi.Services
{
    public class CompaniesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompaniesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CompanyGetDto>> GetAllAsync()
        {
            var companies = await _unitOfWork.Companies.GetAllAsync("Employees");

            return _mapper.Map<List<CompanyGetDto>>(companies);
        }

        public async Task<CompanyGetDto> GetAsync(int id)
        {
            var company = await _unitOfWork.Companies.GetAsync(id);
            company.Employees = await _unitOfWork.Employees.GetFilteredAsync(e => e.CompanyId == company.Id);

            return _mapper.Map<CompanyGetDto>(company);
        }

        public async Task AddAsync(CompanyAddUpdateDto companyDto)
        {
            _unitOfWork.Companies.Add(_mapper.Map<Company>(companyDto));
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(int id, CompanyAddUpdateDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            company.Id = id;

            _unitOfWork.Companies.Update(company);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var company = await _unitOfWork.Companies.GetAsync(id);
            _unitOfWork.Companies.Delete(company);
            await _unitOfWork.SaveAsync();
        }
    }
}
