using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DnD.Models
{
    public class Dragon
    {
        public Dragon()
        {
            this.Killers = new HashSet<Hero>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Description { get; set; }
        [Required]
        public int AttackPower { get; set; }
        [Required]
        public int DeffencePower { get; set; }
        public int Health { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public virtual ICollection<Hero> Killers { get; set; }

    }
}
