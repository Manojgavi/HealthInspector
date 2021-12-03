using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Models
{
    public class Clinic
    {


        [Key]
        public int Id { get; set; }

        public string ClinicName { get; set; }
        public string Address{ get; set; }
        public string ClinicId{ get; set; }

        public  string FacilitiesAvailable { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public int LocalityId{ get; set; }
        public Locality  Locality{ get; set; }
    }
}
