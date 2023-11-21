using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Models.Dtos
{
    public record UpdateAnimalDto
    {
        [Required]
        [StringLength(25)]
        public string? Name { get; init; }
        [Required]
        [StringLength(50)]
        public string? Species { get; init; }
        [Required]
        [Range(1,100)]
        public int Age { get; init; }
        [Required]
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be 'Male' or 'Female'.")]
        public string? Gender { get; init; }
    }
}
