using HR_Models.Models.VM;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models
{
    public class Rewards: Entity // مكافأت
    {
        //public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee? Employee { get; set; }

        public DateTime Date_Rewards { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
        public string Path_file { get; set; }
        public Decimal Price_Rewards { get; set; }
        public string Reason_Reward { get; set; }
        public Rewards()
        {
            //Id = Guid.NewGuid();
        }
    }
}
