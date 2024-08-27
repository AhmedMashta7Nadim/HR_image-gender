using HR_Models.Models.VM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models
{
    public class City: Entity
    {
 
        public string city { get; set; }
        public List<Employee> employees { get; set; } = new List<Employee>();


        public City()
        {
        }


    }
}
