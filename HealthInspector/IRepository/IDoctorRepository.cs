using HealthInspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.IRepository
{
    public interface IDoctorRepository
    {
        void PostDoctorSpeciality(DoctorSpecality doctorSpecality);
        void PostDoctorAvailability(DoctorAvailability doctorAvailability);
    }
}
