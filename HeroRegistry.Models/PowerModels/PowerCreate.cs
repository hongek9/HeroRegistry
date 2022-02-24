using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Models.PowerModels
{
    public class PowerCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string PowerDescription { get; set; }

        [Required]
        public int PowerRating { get; set; }
    }
}
