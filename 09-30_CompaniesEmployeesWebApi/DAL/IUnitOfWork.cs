using _09_30_CompaniesEmployeesWebApi.DAL.IRepositories;
using _09_30_CompaniesEmployeesWebApi.Models;
using System;
using System.Threading.Tasks;

namespace _09_30_CompaniesEmployeesWebApi.DAL
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<Company> Companies { get; }
        IRepository<Employee> Employees { get; }
        Task<int> SaveAsync();
    }
}
