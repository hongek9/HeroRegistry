using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Data
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Required]
        public string JobDescription { get; set; }

        [Required]
        public int TotalPowerRatingRequired { get; set; }

        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        [ForeignKey(nameof(HeroJob))]
        public int HeroJobId { get; set; }

        public virtual HeroJob HeroJob { get; set; }

    }
}
