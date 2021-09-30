using System.Collections.Generic;

namespace _09_30_CompaniesEmployeesWebApi.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
