using HeroRegistry.Models.HeroModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Models.HeroJobModels
{
    public class HeroJobDetails
    {
        public int HeroJobId { get; set; }

        public IEnumerable<HeroInHeroJob> Heroes { get; set; }
        public string JobStatus { get; set; }
    }
}
