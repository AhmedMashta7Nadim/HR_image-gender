using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models.VM
{
    public class CitySummary
    {
        public Guid Id { get; set; }
        public string city { get; set; }
        public CitySummary()
        {
            Id = Guid.NewGuid();
        }
    }
}
