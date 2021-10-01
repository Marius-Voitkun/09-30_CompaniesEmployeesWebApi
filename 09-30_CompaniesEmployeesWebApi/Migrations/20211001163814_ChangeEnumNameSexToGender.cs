using Microsoft.EntityFrameworkCore.Migrations;

namespace _09_30_CompaniesEmployeesWebApi.Migrations
{
    public partial class ChangeEnumNameSexToGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "Employees",
                newName: "Gender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Employees",
                newName: "Sex");
        }
    }
}
