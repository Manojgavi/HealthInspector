using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ViewModels
{
    public class ClinicDataViewModel
    {
        public int Id { get; set; }
        public string ClinicName { get; set; }
        public string Address { get; set; }
        public string ClinicId { get; set; }

        public string FacilitiesAvailable { get; set; }

       
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public int LocalityId { get; set; }
        public string Locality { get; set; }
    }
}
