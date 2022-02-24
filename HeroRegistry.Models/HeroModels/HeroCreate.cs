using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroRegistry.Models.HeroModels
{
    public class HeroCreate
    {
        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string RealFullName { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string HeroName { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string HomeBase { get; set; }

        [Required]
        public int PowerId { get; set; }
        public int HeroJobId { get; set; }
    }
}
