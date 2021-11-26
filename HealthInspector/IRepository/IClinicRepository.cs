using HealthInspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.IRepository
{
    public interface IClinicRepository
    {
        List<Clinic> GetClinics();
        Clinic GetClinic(int Id);
        void PostClinic(Clinic Clinic);

    }
}
