using HR_Models.Models.VM;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HR_Models.Models
{
    public class Penalties: Entity
    {
        //public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public Employee? Employee { get; set; }

        public DateTime Date_Penalties { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
        public string Path_file { get; set; }
        public Decimal Price_Penalties { get; set; }
        public string Reason_Penalties { get; set; }
        public Penalties()
        {
            //Id = Guid.NewGuid();
        }
    }
}
