using HeroRegistry.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Models.LocationModels
{
    public class LocationCreate
    {
        [Required]
        public string LocationName { get; set; }
    }
}
