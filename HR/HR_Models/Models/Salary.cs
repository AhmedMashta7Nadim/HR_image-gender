using HR_Models.Models.VM;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Models.Models
{
    public class Salary : Entity
    {
        public required DateTime Date_Salarys { get; set; }
        public int? Month
        {
            get
            {
                return Date_Salarys.Month;
            }
        }
        public int? Year
        {
            get
            {
                return Date_Salarys.Year;
            }
        }
        public Guid EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee? Employee { get; set; }
        public DateTime Receipt_Date { get; set; }
        public DateTime Issue_Date { get; set; }



        public Salary()
        {


        }
    }
}
