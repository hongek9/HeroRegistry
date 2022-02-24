using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Models.JobModels
{
    public class JobCreate
    {

        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string JobDescription { get; set; }

        [Required]
        public int TotalPowerRatingRequired { get; set; }

        [Required]
        public int LocationId { get; set; }

        public int HeroJobId { get; set; }


    }
}
