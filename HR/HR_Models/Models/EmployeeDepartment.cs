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
    public class EmployeeDepartment: Entity
    {
        //public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid DepartmentId { get; set; }
        public DateTime CreatedAt { get; set; } // Start
        public DateTime? EndAt { get; set; } // End

        //[NotMapped]
        //public IFormFile File { get; set; }
        //public string Path_File { get; set; }
        public bool Is_available { get; set; } = true;//هل هو مستمر
        public bool Is_manager { get; set; } // هل هو مدير


        public EmployeeDepartment()
        {
            //Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            if (!Is_available)
            {
                Is_manager = false;
            }
        }

    }
}
