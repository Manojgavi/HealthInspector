using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Models
{
    public class Locality
    {
        [Key]
        public int Id { get; set; }
        public string Zipcode { get; set; }
    }
}
