using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Models.JobModels
{
    public class JobEdit
    {
        public int JobId { get; set; }

        public string JobDescription { get; set; }

        public int TotalPowerRatingRequired { get; set; }

        public int LocationId { get; set; }

        public int HeroJobId { get; set; }
    }
}
