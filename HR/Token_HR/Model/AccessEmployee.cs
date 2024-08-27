using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR_Models.Models;

namespace Token_HR.Model
{
    public class AccessEmployee
    {
        public Guid Id { get; set; }
        public Guid IdEmployee { get; set; }
        public string Role { get; set; }
    }
}



