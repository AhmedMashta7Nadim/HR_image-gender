using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models.VM
{
    public class RewardsSummary
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime Date_Rewards { get; set; }
        public string Path_file { get; set; }
        public Decimal Price_Rewards { get; set; }
        public string Reason_Reward { get; set; }
    }
}
