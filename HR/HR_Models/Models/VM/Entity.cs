using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Models.Models.VM
{
    public class Entity
    {
        public Guid id { get; set; }

        public Entity()
        {
            id = new Guid();
        }
    }
}
