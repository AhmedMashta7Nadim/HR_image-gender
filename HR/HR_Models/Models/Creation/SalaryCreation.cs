using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models.Creation
{
    public class SalaryCreation
    {
        public Guid EmployeeId { get; set; }
        public required DateTime Date_Salarys { get; set; }
        public DateTime Receipt_Date { get; set; }
        public DateTime Issue_Date { get; set; }
    }
}
