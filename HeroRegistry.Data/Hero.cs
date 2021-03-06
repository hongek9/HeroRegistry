using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Data
{
    public class Hero
    {
        [Key]
        public int HeroId { get; set; }

        [Required]
        public string RealFullName { get; set; }

        [Required]
        public string HeroName { get; set; }

        [Required]
        public string HomeBase { get; set; }

        [ForeignKey(nameof(Power))]
        public int PowerId { get; set; }
        public virtual Power Power { get; set; }

        [ForeignKey(nameof(HeroJob))]
        public int HeroJobId { get; set; }
        public virtual HeroJob HeroJob { get; set; }
    }
}
