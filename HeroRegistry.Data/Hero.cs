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
        public string RealFullName { get; set; }
        public string HeroName { get; set; }
        public string HomeBase { get; set; }

        [ForeignKey(nameof(Power))]
        public int PowerId { get; set; }
        public virtual Power Power { get; set; }

        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        public virtual Job Job { get; set; }


    }
}
