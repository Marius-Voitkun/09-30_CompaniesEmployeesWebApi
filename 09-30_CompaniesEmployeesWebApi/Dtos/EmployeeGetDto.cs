namespace _09_30_CompaniesEmployeesWebApi.Dtos
{
    public class EmployeeGetDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public int? CompanyId { get; set; }

        public string CompanyName { get; set; }
    }
}
