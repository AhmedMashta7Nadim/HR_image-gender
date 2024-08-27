using HR_Models.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models
{
    public class UniverCity: Entity
    {
        public string Name { get; set; }
        public List<Employee> employees { get; set; } = new List<Employee>();
        public UniverCity()
        {

        }

    }
}
