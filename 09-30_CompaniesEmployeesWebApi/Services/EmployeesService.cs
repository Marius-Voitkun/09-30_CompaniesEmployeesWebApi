using _09_30_CompaniesEmployeesWebApi.DAL;
using _09_30_CompaniesEmployeesWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _09_30_CompaniesEmployeesWebApi.Services
{
    public class EmployeesService
    {
        private readonly UnitOfWork _unitOfWork;

        public EmployeesService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _unitOfWork.Employees.GetAllAsync();
        }

        public async Task<Employee> GetAsync(int id)
        {
            return await _unitOfWork.Employees.GetAsync(id);
        }

        public async Task AddAsync(Employee employee)
        {
            _unitOfWork.Employees.Add(employee);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _unitOfWork.Employees.Update(employee);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetAsync(id);
            _unitOfWork.Employees.Delete(employee);
            await _unitOfWork.SaveAsync();
        }
    }
}
