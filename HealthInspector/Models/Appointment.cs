using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DoctorAvailabilityId { get; set; }
        public DoctorAvailability DoctorAvailability { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }

    }
}
