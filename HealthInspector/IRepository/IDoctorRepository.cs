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
        DoctorSpecality GetDoctorSpeciality(int id);
        List<DoctorAvailability> GetDoctorAvailabilities(int id);
        List<DoctorAvailability> GetDoctorAvailabilities();
        List<DoctorSpecality> GetDoctorSpecialities();
        List<DoctorAvailability> GetDoctorAvailability(int id);
        DoctorAvailability GetDoctorAvailabilityById(int id);
        
    }
}
