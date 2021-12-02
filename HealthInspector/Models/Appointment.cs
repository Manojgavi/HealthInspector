using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        //public User User { get; set; }
        [Required]
        public int DoctorAvailabilityId { get; set; }
        public DoctorAvailability DoctorAvailability { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime AppointmentDate { get; set; }
        [DataType(DataType.MultilineText)]
       
        public string Message { get; set; }
        [Required]
        public string Status { get; set; }

    }
}