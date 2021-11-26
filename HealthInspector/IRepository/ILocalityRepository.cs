using HealthInspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.IRepository
{
    public interface ILocalityRepository
    {
        List<Locality> GetLocalities();
        Locality GetLocality(int id);
       // Locality GetLocality(int zipcode);
        bool postLocality(Locality locality);

    }
}
