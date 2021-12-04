using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ViewModels
{
    public class FeedbackDataViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Clinic")]
        public string ClinicName { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Feedback")]
        public string Review { get; set; }

        
    }
}
