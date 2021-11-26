using HealthInspector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.IControllerServices
{
    public interface IClinicServices
    {
        ClinicViewModel Create();
        void PostClinic(ClinicViewModel clinic);
        List<ClinicDataViewModel> GetClinics();
    }
}
