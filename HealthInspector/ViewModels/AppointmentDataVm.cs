using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ViewModels
{
    public class AppointmentDataVm
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string ClinicName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
