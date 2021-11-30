using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        public string DoctorId {get; set;}

        public string UserId { get; set; }

        public string Review { get; set; }

    }
}
