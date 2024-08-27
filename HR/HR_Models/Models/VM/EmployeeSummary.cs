using HR_Models.EnumClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models.VM
{
    public class EmployeeSummary
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Father { get; set; }
        public string LastName { get; set; }
        public string Mather { get; set; }
        public Gendar gendar { get; set; }
        public DateTime BirthDate { get; set; }
        public int? Age { get; set; }
        public DateTime date_of_employment { get; set; }
        public decimal Salary_basis { get; set; }
        public string Functional_ID { get; set; }
        public Guid CityId { get; set; }
        public Guid UniverCityId { get; set; }
        public string Path_Img { get; set; }


        public EmployeeSummary()
        {
            
        }


    }
}
