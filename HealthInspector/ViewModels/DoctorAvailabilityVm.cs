using HealthInspector.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ViewModels
{
    public class DoctorAvailabilityVm
    {
        public int Id { get; set; }

        [Required]
        public DayOfWeek Day { get; set; }
        
        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [Required]
        public int ClinicId { get; set; }
        public List<Clinic> Clinic { get; set; }
        public int UserId { get; set; }
        
    }
}
