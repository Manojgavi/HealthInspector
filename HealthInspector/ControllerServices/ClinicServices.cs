using AutoMapper;
using HealthInspector.IControllerServices;
using HealthInspector.IRepository;
using HealthInspector.Models;
using HealthInspector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ControllerServices
{
    public class ClinicServices : IClinicServices
    {
        private readonly ILocalityRepository localityRepository;
        private readonly IClinicRepository clinicRepository;
        //private readonly ILocalityRepository localityRepository;
        private readonly IMapper mapper;

        public ClinicServices(ILocalityRepository localityRepository,IClinicRepository clinicRepository,IMapper mapper)
        {
            this.localityRepository = localityRepository;
            this.clinicRepository = clinicRepository;
            this.mapper = mapper;
        }
        public ClinicViewModel Create()
        {
            ClinicViewModel clinicViewModel = new ClinicViewModel();
            clinicViewModel.Locality = localityRepository.GetLocalities();

            return clinicViewModel;
        }

        public List<ClinicDataViewModel> GetClinics()
        {
            List<ClinicDataViewModel> clinicDataViewModels = new List<ClinicDataViewModel>();
            List<Clinic> clinics = new List<Clinic>();
            clinics=clinicRepository.GetClinics();
            List<Locality> localities = new List<Locality>();
            localities = localityRepository.GetLocalities();

            var result = (from clinic in clinics
                          join locality in localities
                          on clinic.LocalityId equals locality.Id
                          select new
                          {
                              Id = clinic.Id,
                              ClinicName = clinic.ClinicName,
                              Address = clinic.Address,
                              ClinicId = clinic.ClinicId,
                              FacilitiesAvailable = clinic.FacilitiesAvailable,
                              PhoneNumber = clinic.PhoneNumber,
                              Website = clinic.Website,
                              LocalityId = clinic.LocalityId,
                              LocalityName = locality.Zipcode

                          }
                        );
            foreach(var clinic in result)
            {
                ClinicDataViewModel clinicData = new ClinicDataViewModel()
                {
                    Id = clinic.Id,
                    ClinicName = clinic.ClinicName,
                    Address = clinic.Address,
                    ClinicId = clinic.ClinicId,
                    FacilitiesAvailable = clinic.FacilitiesAvailable,
                    PhoneNumber = clinic.PhoneNumber,
                    Website = clinic.Website,
                    LocalityId = clinic.LocalityId,
                    Locality = clinic.LocalityName
                };
                clinicDataViewModels.Add(clinicData);

            }
            return clinicDataViewModels;
        }

        public void PostClinic(ClinicViewModel clinicViewModel)
        {
            clinicViewModel.FacilitiesAvailable =String.Join(", ", clinicViewModel.FacilitiesSelected);
            Clinic clinic = new Clinic();
            
            clinic = mapper.Map<Clinic>(clinicViewModel);
            clinicRepository.PostClinic(clinic);
        }
    }
}
