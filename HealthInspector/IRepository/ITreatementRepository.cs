using HealthInspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.IRepository
{
    public interface ITreatementRepository
    {
        string LastPatientId(string first);
        void PostTreatement(Treatment treatment);
    }
}
