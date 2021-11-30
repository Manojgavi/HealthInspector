using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ViewModels
{
    public class QuestionnaireViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Quality of medical care?")]
        public string Question1 { get; set; }

        [Required]
        [Display(Name = "How would you rate the professionalism of our staff?")]
        public string Question2 { get; set; }

        [Required]
        [Display(Name = "Did you have any issues arranging an appointment?")]
        public string Question3 { get; set; }

        [Required]
        [Display(Name = "Are you currently covered under a health insurance plan?")]
        public string Question4 { get; set; }

        [Required]
        [Display(Name = "How would you rate your overall Experience?")]
        public string Question5 { get; set; }
    }
}
