using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Data
{
    public class Job
    {
        public int JobId { get; set; }
        public string JobDescription { get; set; }
        public int TotalPowerRatingRequired { get; set; }
        public Location Location { get; set; }
        public virtual List<Hero> Heroes { get; set; } = new List<Hero>();

    }
}
