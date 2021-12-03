using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthInspector.IControllerServices;
using HealthInspector.IRepository;

namespace HealthInspector.ControllerServices
{
    public class PatientRecordServices : IPatientRecordServices
    {

        private readonly ILocalityRepository localityRepository;
        private readonly IClinicRepository clinicRepository;
        private readonly IMapper mapper;

        public string PatientId()
        {
           return clinicRepository..Substring(0, 3)
        }
    }
}
