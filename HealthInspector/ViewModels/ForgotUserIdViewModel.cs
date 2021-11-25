using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ViewModels
{
    public class ForgotUserIdViewModel
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "What is your Pet Name?")]
        public string Answer1 { get; set; }
        [Required]
        [Display(Name = "What is your First college name?")]
        public string Answer2 { get; set; }
        [Required]
        [Display(Name = "What is your Best friend name?")]
        public string Answer3 { get; set; }
    }
}
