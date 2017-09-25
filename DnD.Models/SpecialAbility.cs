using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DnD.Models
{
    public class SpecialAbility
    {

        
        
        [Key]
        public int Id { get; set; }
        [MaxLength(25)]
        [Required]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public SpecialAbilityType AblityType { get; set; }
        [Required]
        public int Power { get; set; }
        public virtual ICollection<Hero> Heroes { get; set; }

        
    }
    public enum SpecialAbilityType
    {       
        Attack,
        Deffence
    }
}
