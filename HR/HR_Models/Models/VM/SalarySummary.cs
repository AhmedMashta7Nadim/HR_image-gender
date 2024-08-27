using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models.VM
{
    public class SalarySummary
    {
        public Guid Id { get; set; }
        public required DateTime Date_Salarys { get; set; }
        public SalarySummary()
        {
            Month = Date_Salarys.Month;
            Year = Date_Salarys.Year;

        }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime Receipt_Date { get; set; }
        public DateTime Issue_Date { get; set; }
    }
}
