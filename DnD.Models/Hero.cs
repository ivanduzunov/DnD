using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DnD.Models
{
    public class Hero
    {
      
        public Hero()
        {
            this.SpecialAbilities = new HashSet<SpecialAbility>();
            this.KilledDragons = new HashSet<Dragon>();
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
        public ICollection<SpecialAbility> SpecialAbilities { get; set; }
        public virtual ICollection<Dragon> KilledDragons { get; set; }

    }
}
