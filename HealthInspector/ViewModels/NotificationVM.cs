using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ViewModels
{
    public class NotificationVM
    {
        public NotificationVM()
        {
            Appointment = false;
            Revisit = false;
        }
        public bool Appointment { get; set; }
        public bool Revisit { get; set; }
        public bool Review { get; set; }
    }
}
