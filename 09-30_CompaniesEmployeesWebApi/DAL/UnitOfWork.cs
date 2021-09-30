using _09_30_CompaniesEmployeesWebApi.DAL.IRepositories;
using _09_30_CompaniesEmployeesWebApi.DAL.Repositories;
using _09_30_CompaniesEmployeesWebApi.Models;
using System.Threading.Tasks;

namespace _09_30_CompaniesEmployeesWebApi.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IRepository<Company> Companies { get; private set; }
        public IRepository<Employee> Employees { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Companies = new Repository<Company>(_context);
            Employees = new Repository<Employee>(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();      // is this correct?
        }
    }
}
