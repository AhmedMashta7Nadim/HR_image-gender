using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models.Creation
{
    public class EmployeeDepartmentCreation
    {
        public Guid EmployeeId { get; set; }
        public Guid DepartmentId { get; set; }
        public DateTime? EndAt { get; set; } // End
        //public string Path_File { get; set; }
        public bool Is_available { get; set; }//هل هو مستمر
        public bool Is_manager { get; set; } // هل هو مدير
    }
}
