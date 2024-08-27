using AutoMapper;
using HR_Models.Models.Creation;
using HR_Models.Models.VM;
using Microsoft.AspNetCore.JsonPatch;

namespace HR_Models.Models.Profile_Map
{
    public class Map : Profile
    {

        public Map()
        {
            CreateMap<Employee, EmployeeSummary>();
            CreateMap<EmployeeSummary, Employee>();
            CreateMap<Employee, EmployeeCreation>();
            CreateMap<EmployeeCreation, Employee>();
            CreateMap<EmployeeCreation, EmployeeSummary>();
            CreateMap<EmployeeSummary, EmployeeCreation>();



            CreateMap<City, CitySummary>();
            CreateMap<CitySummary, City>();
            CreateMap<CityCreation, CitySummary>();
            CreateMap<CitySummary, CityCreation>();
            CreateMap<CityCreation, City>();
            CreateMap<City, CityCreation>();


            CreateMap<UniverCity, UniverCitySummary>();
            CreateMap<UniverCitySummary, UniverCity>();
            CreateMap<UniverCityCreation, UniverCity>();
            CreateMap<UniverCity, UniverCityCreation>();
            CreateMap<UniverCityCreation, UniverCitySummary>();
            CreateMap<UniverCitySummary, UniverCityCreation>();


            CreateMap<Salary, SalarySummary>();
            CreateMap<SalarySummary, Salary>();
            CreateMap<SalaryCreation, Salary>();
            CreateMap<Salary, SalaryCreation>();
            CreateMap<SalaryCreation, SalarySummary>();
            CreateMap<SalarySummary, SalaryCreation>();




            CreateMap<EmployeeDepartment, EmployeeDepartmentSummary>();
            CreateMap<EmployeeDepartmentSummary, EmployeeDepartment>();
            CreateMap<EmployeeDepartmentCreation, EmployeeDepartment>();
            CreateMap<EmployeeDepartment, EmployeeDepartmentCreation>();
            CreateMap<EmployeeDepartmentCreation, EmployeeDepartmentSummary>();
            CreateMap<EmployeeDepartmentSummary, EmployeeDepartmentCreation>();









            CreateMap<Department, DepartmentSummary>();
            CreateMap<DepartmentSummary, Department>();
            CreateMap<DepartmentCreation, Department>();
            CreateMap<Department, DepartmentCreation>();
            CreateMap<DepartmentCreation, DepartmentSummary>();
            CreateMap<DepartmentSummary, DepartmentCreation>();



            CreateMap<Penalties, PenaltiesSummary>();
            CreateMap<PenaltiesSummary, Penalties>();
            CreateMap<PenaltiesCreation, Penalties>();
            CreateMap<Penalties, PenaltiesCreation>();
            CreateMap<PenaltiesCreation, PenaltiesSummary>();
            CreateMap<PenaltiesSummary, PenaltiesCreation>();




            CreateMap<Vacation, VacationSummary>();
            CreateMap<VacationSummary, Vacation>();
            CreateMap<VacationCreation, Vacation>();
            CreateMap<Vacation, VacationCreation>();
            CreateMap<VacationCreation, VacationSummary>();
            CreateMap<VacationSummary, VacationCreation>();





            CreateMap<Rewards, RewardsSummary>();
            CreateMap<RewardsSummary, Rewards>();
            CreateMap<RewardsCreation, Rewards>();
            CreateMap<Rewards, RewardsCreation>();
            CreateMap<RewardsCreation, RewardsSummary>();
            CreateMap<RewardsSummary, RewardsCreation>();



            //-------------------------------------
            CreateMap<JsonPatchDocument<Employee>, EmployeeSummary>();
            CreateMap<Employee, EmployeeSummary>();
            CreateMap<EmployeeSummary, Employee>();
        }
        //Rewards
    }
}
