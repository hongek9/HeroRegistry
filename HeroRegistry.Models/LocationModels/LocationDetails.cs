using HeroRegistry.Models.JobModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Models.LocationModels
{
    public class LocationDetails
    {    
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public  List<JobInLocation> Jobs { get; set; }
    }
}
