using HR_Models.EnumClass;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models.Creation
{
    public class EmployeeCreation
    {
        public IFormFile Img { get; set; }
        public string Name { get; set; }
        public string Father { get; set; }
        public string LastName { get; set; }
        public string Mather { get; set; }
        public Gendar gendar { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime date_of_employment { get; set; }
        public decimal Salary_basis { get; set; }
        public enum_Functional Functional_ID { get; set; } = enum_Functional.User;
        public Guid CityId { get; set; }
        public Guid UniverCityId { get; set; }
        //public Department dep { get; set; }
        //public List<Department> dep { get; set; } = new List<Department>();


        public EmployeeCreation()
        {
            Console.WriteLine(CityId);
        }
    }
}
