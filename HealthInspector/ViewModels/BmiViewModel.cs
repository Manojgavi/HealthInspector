using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ViewModels
{
    public class BmiViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Height is Required")]
        [Display(Name = "Height (in Meter)")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Weight is Required")]
        [Display(Name = "Weight (in Kg)")]
        public double Weight { get; set; }
    }
}
