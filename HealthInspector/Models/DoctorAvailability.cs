using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Models
{
    public class DoctorAvailability
    {
        public int Id { get; set; }
        
        public DayOfWeek Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
