using HeroRegistry.Data;
using HeroRegistry.Models.HeroJobModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Models.JobModels
{
    public class JobInLocation
    {
        public int JobId { get; set; }

        public string JobDescription { get; set; }

        public int TotalPowerRatingRequired { get; set; }

        public HeroJobDetails HeroJob { get; set; }
    }
}
