using HeroRegistry.Models.HeroJobModels;
using HeroRegistry.Models.LocationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Models.JobModels
{
    public class JobDetails
    {
        public int JobId { get; set; }

        public string JobDescription { get; set; }

        public int TotalPowerRatingRequired { get; set; }

        public LocationDetails Location { get; set; }

    }
}
