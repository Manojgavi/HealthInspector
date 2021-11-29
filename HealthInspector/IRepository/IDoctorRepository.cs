using HealthInspector.Models;
using HealthInspector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.IRepository
{
    public interface IDoctorRepository
    {
        void PostDoctorSpeciality(DoctorSpecalityVm doctorSpecality);
        void PostDoctorAvailability(DoctorAvailability doctorAvailability);
    }
}
