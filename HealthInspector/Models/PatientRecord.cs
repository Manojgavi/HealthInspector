using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Models
{
    public class PatientRecord
    {
        [Key]
        public int Id { get; set; }

        public string ClinicName { get; set; }

        public string Doctor { get; set; }



        public string PatientId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public DateTime VisitDate { get; set; }

        public string DoctorName { get; set; }

        public string Speciality { get; set; }


    }
}
