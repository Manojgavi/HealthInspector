using HealthInspector.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ViewModels
{
    public class FeedbackViewModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Select Clinic")]
        public string DoctorId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Feedback")]
        public string Review { get; set; }

        public List<Clinic> Clinics { get; set; }

    }
}
