using HR_Models.Models.VM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models
{
    public class Leave_Balances: Entity //أرصدة إجازات الموظف
    {
        //public Guid Id { get; set; }

        public Guid EmployeeId  { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee? Employee { get; set; }
        public int Remaining_Balance { get; set; } //الرصيد المتبقي
        public Decimal Total_Balance { get; set; } //الرصيد الإجمالي
        public int Carryover_Balance { get; set; }//الرصيد المدور

        public Leave_Balances()
        {
            //Id = Guid.NewGuid();
        }
    }
}
