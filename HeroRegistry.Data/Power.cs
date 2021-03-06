using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Data
{
    public class Power
    {   
        [Key]
        public int PowerId { get; set; }

        [Required]
        public string PowerDescription { get; set; }

        [Required]
        public int PowerRating { get; set; }
    }
}
