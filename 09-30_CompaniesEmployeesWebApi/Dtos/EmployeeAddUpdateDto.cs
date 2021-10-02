namespace _09_30_CompaniesEmployeesWebApi.Dtos
{
    public class EmployeeAddUpdateDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public int? CompanyId { get; set; }
    }
}
