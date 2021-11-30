using HealthInspector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.IControllerServices
{
    public interface IDoctorServices
    {
        void PostDoctorAvailability(DoctorAvailabilityVm doctorAvailabilityVm);
        void PostDoctorSpeciality(DoctorSpecalityVm doctorSpecalityvm);
        DoctorAvailabilityVm GenerateAvailability();

        List<DoctorDataViewModel> GetDoctorData(int id);
    }
}
