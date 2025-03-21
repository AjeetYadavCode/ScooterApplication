using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScooterApplication.Models
{
    public class ScooterWheelLife
    {
        [Required(ErrorMessage = "Wheel 1 is required.")]
        public int Wheel1 { get; set; }

        [Required(ErrorMessage = "Wheel 2 is required.")]
        public int Wheel2 { get; set; }

        public int? Spare { get; set; }
        public double? MaxDistance { get; set; }
    
}
}