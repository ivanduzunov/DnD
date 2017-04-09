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

        //It would have different interesting names, 
        //but it will just increase the deffence or the attack power of the Hero. It would be given, after every killing
        
        [Key]
        public int Id { get; set; }
        [MaxLength(15)]
        [Required]
        public string Name { get; set; }
        [MaxLength(30)]
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
