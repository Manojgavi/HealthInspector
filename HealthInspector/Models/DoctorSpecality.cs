using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Models
{
    public class DoctorSpecality
    {
        public int Id { get; set; }
        public string Speciality { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        //public int[] DoctorAvailabilityId { get; set; }
        //public List<DoctorAvailability> DoctorAvailabilities { get; set; }
    }
}
