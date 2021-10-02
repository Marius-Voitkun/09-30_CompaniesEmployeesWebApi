using _09_30_CompaniesEmployeesWebApi.DAL;
using _09_30_CompaniesEmployeesWebApi.Dtos;
using _09_30_CompaniesEmployeesWebApi.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _09_30_CompaniesEmployeesWebApi.Services
{
    public class EmployeesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<EmployeeGetDto>> GetAllAsync()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync("Company");

            return _mapper.Map<List<EmployeeGetDto>>(employees);
        }

        public async Task<EmployeeGetDto> GetAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetAsync(id);
            employee.Company = await _unitOfWork.Companies.GetSingleOrDefaultAsync(c => c.Id == employee.CompanyId);

            return _mapper.Map<EmployeeGetDto>(employee);
        }

        public async Task AddAsync(EmployeeAddUpdateDto employeeDto)
        {
            _unitOfWork.Employees.Add(_mapper.Map<Employee>(employeeDto));
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(int id, EmployeeAddUpdateDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            employee.Id = id;

            _unitOfWork.Employees.Update(employee);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetAsync(id);
            _unitOfWork.Employees.Delete(employee);
            await _unitOfWork.SaveAsync();
        }
    }
}
