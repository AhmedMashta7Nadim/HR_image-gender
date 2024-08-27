using Azure.Core;
using HR.Repositry.ServesToken;
using HR_Models.Models;
using Microsoft.EntityFrameworkCore;
using Token_HR.Model;

namespace HR.Data
{
    public class HR_Context:DbContext
    {
        private readonly IAccessEmployeeRepositry accessEmployee;

        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<City> citys { get; set; }
        public DbSet<UniverCity> univers { get; set; }
        public DbSet<Salary> salaries { get; set; }
        public DbSet<Vacation> vacations { get; set; }
        public DbSet<Leave_Balances> balances { get; set; }
        public DbSet<Rewards> rewards { get; set; }
        public DbSet<Penalties> penalties { get; set; }
        public DbSet<AccessEmployee> accessEmployees { get; set; }


        public HR_Context(DbContextOptions<HR_Context> options):base(options)
        {
            
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(x => x.departments)
                .WithMany(x => x.employees)
                .UsingEntity<EmployeeDepartment>();

            modelBuilder.Entity<Employee>()
                .HasMany(x => x.salaries)
                .WithOne(x => x.Employee)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<City>().HasData(
                new City()
                {
                    id=  new Guid("685f4dec-1e5a-4881-817c-932cdd4caf67"),
                   city="mozambic", 
                }
                );

            modelBuilder.Entity<UniverCity>().HasData(
                new UniverCity()
                {
                    id = new Guid("4b5aed57-60e4-4710-9855-a35970991117"),
                    Name = "Sham",
                }
                );
            modelBuilder.Entity<Employee>().HasData(
              new Employee()
                {
                    id = new Guid("5e44452c-4f92-4461-9acb-84c9251ea9cf"),
                    Name="MohamedIsmail",
                    LastName="Ismail",
                    Mather="sss",
                    Father="Ismail",
                    BirthDate=new DateTime(2000,1,1),
                    Functional_ID=HR_Models.EnumClass.enum_Functional.Admin,
                    IsActive=true,
                    date_of_employment=new DateTime(2000,1,1),
                    Salary_basis=1,
                    UniversityDegree= HR_Models.EnumClass.University_degree.Doctor,
                    CityId = Guid.Parse("685f4dec-1e5a-4881-817c-932cdd4caf67"),
                    UniverCityId=Guid.Parse("4b5aed57-60e4-4710-9855-a35970991117"),
              }
            );

            modelBuilder.Entity<AccessEmployee>().HasData(
               new AccessEmployee()
               {
                   Id= new Guid("ec72e51d-8c19-41b0-9e64-fe8c636f65fc"),
                   IdEmployee= Guid.Parse("5e44452c-4f92-4461-9acb-84c9251ea9cf"),
                   Role="Admin"
               }
               );

        }
    }
}


