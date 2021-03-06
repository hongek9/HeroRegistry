using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Data
{
    public class HeroJob
    {
        [Key]
        public int HeroJobId { get; set; }

        public virtual List<Hero> Heroes { get; set; } = new List<Hero>();
        public string JobStatus { get; set; }
    }
}
