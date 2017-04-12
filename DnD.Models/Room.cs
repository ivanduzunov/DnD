using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Models
{
    public class Room
    {
        public Room()
        {
            this.Dragons = new HashSet<Dragon>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Dragon> Dragons { get; set; }

    }
}
