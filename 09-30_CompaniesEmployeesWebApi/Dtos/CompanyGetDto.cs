using System.Collections.Generic;

namespace _09_30_CompaniesEmployeesWebApi.Dtos
{
    public class CompanyGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<EmployeeInGetCompanyDto> Employees { get; set; }
    }
}
