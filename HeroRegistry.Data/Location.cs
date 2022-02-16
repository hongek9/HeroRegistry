using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Data
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
