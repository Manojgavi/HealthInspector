using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ViewModels
{
    public class DoctorDataViewModel
    {
        public int Id { get; set; }
        public string Speciality { get; set; }
        
        public DayOfWeek Day { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        public string ClinicName { get; set; }
        //public int UserId { get; set; }

    }
}
