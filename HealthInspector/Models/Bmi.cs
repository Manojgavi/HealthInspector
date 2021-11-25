using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Models
{
    public class Bmi
    {
        [Key]
        public int Id { get; set; }

        
        public double Height { get; set; }

       
        public double Weight { get; set; }
    }
}
