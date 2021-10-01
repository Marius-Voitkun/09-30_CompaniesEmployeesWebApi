using _09_30_CompaniesEmployeesWebApi.DAL;
using _09_30_CompaniesEmployeesWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _09_30_CompaniesEmployeesWebApi.Services
{
    public class CompaniesService
    {
        private readonly UnitOfWork _unitOfWork;

        public CompaniesService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _unitOfWork.Companies.GetAllAsync();
        }

        public async Task<Company> GetAsync(int id)
        {
            return await _unitOfWork.Companies.GetAsync(id);
        }

        public async Task AddAsync(Company company)
        {
            _unitOfWork.Companies.Add(company);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            _unitOfWork.Companies.Update(company);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var company = await GetAsync(id);
            _unitOfWork.Companies.Delete(company);
            await _unitOfWork.SaveAsync();
        }
    }
}
