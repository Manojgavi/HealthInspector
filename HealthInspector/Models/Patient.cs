using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Models
{
    public class Patient
    {
        [Key]
        public int  Id { get; set; }
        [Required]
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string PatienttId { get; set; }
        
        public int VisitDate { get; set; }
        public string DoctorName { get; set; }
        public string  Specality { get; set; }

    }
}
