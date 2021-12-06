using HealthInspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ViewModels
{
    public class HelpViewModel
    {
        public string UserId { get; set; }
        public string Issue { get; set; }
        public string Description { get; set; }
        public int? Select { get; set; } 
    }
}
