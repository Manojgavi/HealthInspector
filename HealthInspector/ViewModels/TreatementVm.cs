using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ViewModels
{
    public class TreatementVm
    {
       
        public int Id { get; set; }
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public string Symptoms { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        [Required]
        public string PatientId { get; set; }
        [Required]
        public string TreatmentPlanned { get; set; }
        [Required]
        public string Prescription { get; set; }
        
        public string RevisitRequired { get; set; }
        
        public DateTime NextRevisitDate { get; set; }
        public string FrequencyRevisit { get; set; }
    }
}
