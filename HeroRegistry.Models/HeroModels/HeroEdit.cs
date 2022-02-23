using HeroRegistry.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Models.HeroModels
{
    public class HeroEdit
    {
        public int HeroId { get; set; }
        public string RealFullName { get; set; }
        public string HeroName { get; set; }
        public string HomeBase { get; set; }
        public int PowerId { get; set; }
        public int HeroJobId { get; set; }

    }
}
