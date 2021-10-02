using _09_30_CompaniesEmployeesWebApi.Dtos;
using _09_30_CompaniesEmployeesWebApi.Models;
using AutoMapper;

namespace _09_30_CompaniesEmployeesWebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyGetDto>();
            CreateMap<CompanyAddUpdateDto, Company>();

            CreateMap<Employee, EmployeeGetDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));
            CreateMap<Employee, EmployeeInGetCompanyDto>();
            CreateMap<EmployeeAddUpdateDto, Employee>();
        }
    }
}
