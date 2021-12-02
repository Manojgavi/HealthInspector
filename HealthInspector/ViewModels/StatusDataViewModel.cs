using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ViewModels
{
    public class StatusDataViewModel
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string ClinicName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
