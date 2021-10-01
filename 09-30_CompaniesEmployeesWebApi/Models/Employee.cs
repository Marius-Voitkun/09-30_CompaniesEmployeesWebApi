namespace _09_30_CompaniesEmployeesWebApi.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public int? CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
