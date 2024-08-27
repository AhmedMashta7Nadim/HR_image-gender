using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models.VM
{
    public class DepartmentSummary
    {
        public Guid Id { get; set; }
        public string Name_Department { get; set; }
        //public List<Employee> employees { get; set; } = new List<Employee>();
        public bool IsActive { get; set; }

    }
}
