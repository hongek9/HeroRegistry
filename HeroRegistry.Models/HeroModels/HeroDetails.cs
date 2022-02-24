using HeroRegistry.Models.HeroJobModels;
using HeroRegistry.Models.PowerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Models.HeroModels
{
    public class HeroDetails
    {
        public int HeroId { get; set; }
        public string RealFullName { get; set; }
        public string HeroName { get; set; }
        public string HomeBase { get; set; }
        public HeroJobDetails HeroJob { get; set; }

        public PowerDetails Power { get; set; }
    }
}
