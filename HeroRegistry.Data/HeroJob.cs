using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Data
{
    public class HeroJob
    {
        public int HeroJobId { get; set; }
        public List<Hero> Heroes { get; set; }
        public string JobReview { get; set; }
    }
}
