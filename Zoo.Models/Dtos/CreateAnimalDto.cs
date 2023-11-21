﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Models.Dtos
{
    public class CreateAnimalDto
    {
        [Required]
        [StringLength(25)]
        public string? Name { get; set; }
        [Required]
        [StringLength(50)]
        public string? Species { get; set; }
        [Required]
        [Range(1,100)]
        public int Age { get; set; }
        [Required]
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be 'Male' or 'Female'.")]
        public string? Gender { get; set; }

    }
}
