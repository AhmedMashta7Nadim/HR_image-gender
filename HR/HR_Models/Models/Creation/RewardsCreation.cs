using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models.Creation
{
    public class RewardsCreation
    {
        public Guid EmployeeId { get; set; }
        public DateTime Date_Rewards { get; set; }
        public string Path_file { get; set; }
        public Decimal Price_Rewards { get; set; }
        public string Reason_Reward { get; set; }

    }
}
