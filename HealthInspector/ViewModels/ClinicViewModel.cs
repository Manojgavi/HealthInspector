using HealthInspector.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ViewModels
{
    public class ClinicViewModel
    {
        public ClinicViewModel()
        {
            Facilities = new List<SelectListItem>()
            { new SelectListItem{Text="OPD ",Value="OPD "},
            new SelectListItem{Text="Dental facility ",Value="Dental facility "},
            new SelectListItem{Text="Ward/ Indoor facility ",Value="Ward/ Indoor facility "},
             new SelectListItem{Text="Minor OT/ Dressing Room ",Value="Minor OT/ Dressing Room "},
             new SelectListItem{Text="Physiotherapy ",Value="Physiotherapy "},
             new SelectListItem{Text="Laboratory services ",Value="Laboratory services "},
             new SelectListItem{Text="ECG Services ",Value="ECG Services "},
             new SelectListItem{Text="Pharmacy",Value="Pharmacy"},
             new SelectListItem{Text="Radiology/X-ray facility",Value="Radiology/X-ray facility"},
             new SelectListItem{Text="Ambulance Services",Value="Ambulance Services"},
            };
        }
        public int Id { get; set; }
        public string ClinicName { get; set; }
        public string Address{ get; set; }
        public string ClinicId{ get; set; }

        public  string FacilitiesAvailable { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public int LocalityId{ get; set; }
        public IList<Locality>  Locality{ get; set; }

        public List<SelectListItem> Facilities { get; set; }
        public List<String> FacilitiesSelected { get; set; }


    }
}
