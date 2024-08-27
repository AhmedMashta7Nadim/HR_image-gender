using HR_Models.EnumClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models.VM
{
    public class VacationSummary
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime Start_Vacation { get; set; }
        public DateTime End_Vacation { get; set; }
        public Vacation_e Leave { get; set; }
        public string NoteBad { get; set; }
        public bool Acceptance { get; set; }
    }
}
