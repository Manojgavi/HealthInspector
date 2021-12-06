using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public string Symptoms { get; set; }
        public string Diagnosis { get; set; }
        public string PatientId { get; set; }
        public string TreatmentPlanned { get; set; }
        public string Prescription { get; set; }
        public string RevisitRequired { get; set; }
        public DateTime NextRevisitDate { get; set; }
        public string FrequencyRevisit { get; set; }

    }
}
