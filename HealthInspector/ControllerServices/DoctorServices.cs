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
    public class DoctorServices : IDoctorServices
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IMapper mapper;
        private readonly IClinicRepository clinicRepository;

        public DoctorServices(IDoctorRepository doctorRepository, IMapper mapper,IClinicRepository clinicRepository)
        {
            this.doctorRepository = doctorRepository;
            this.mapper = mapper;
            this.clinicRepository = clinicRepository;
        }

        public DoctorAvailabilityVm GenerateAvailability()
        {
            DoctorAvailabilityVm doctorAvailabilityVm = new DoctorAvailabilityVm();
            doctorAvailabilityVm.Clinic = clinicRepository.GetClinics();
            return doctorAvailabilityVm;
        }

        public List<DoctorDataViewModel> GetDoctorData(int id)
        {
            DoctorSpecality doctorSpecality = new DoctorSpecality();
            doctorSpecality= doctorRepository.GetDoctorSpeciality(id);
            List<DoctorAvailability> doctorAvailabilities = new List<DoctorAvailability>();
            doctorAvailabilities = doctorRepository.GetDoctorAvailabilities(id);
            List<Clinic> clinics = new List<Clinic>();
            clinics = clinicRepository.GetClinics();
            List<DoctorDataViewModel> doctorDataViewModels = new List<DoctorDataViewModel>();

            var result = (from doctorAvailability in doctorAvailabilities
                          join clinic in clinics
                          on doctorAvailability.ClinicId equals clinic.Id
                          select new
                          {
                              Id = doctorAvailability.Id,
                              Speciality = doctorSpecality.Speciality,
                              Day = doctorAvailability.Day,
                              StartTime = doctorAvailability.StartTime,
                              EndTime = doctorAvailability.EndTime,
                              ClincName = clinic.ClinicName,

                          });
            foreach(var obj in result)
            {
                DoctorDataViewModel doctorDataViewModel = new DoctorDataViewModel()
                {
                    Id = obj.Id,
                    Speciality = obj.Speciality,
                    Day = obj.Day,
                    StartTime = obj.StartTime,
                    EndTime = obj.EndTime,
                    ClinicName = obj.ClincName
                };
                doctorDataViewModels.Add(doctorDataViewModel);
            }
            return doctorDataViewModels;
        }

        public void PostDoctorAvailability(DoctorAvailabilityVm doctorAvailabilityVm)
        {
            DoctorAvailability doctorAvailability = new DoctorAvailability();
            doctorAvailability = mapper.Map<DoctorAvailability>(doctorAvailabilityVm);
            doctorRepository.PostDoctorAvailability(doctorAvailability);
        }
        public void PostDoctorSpeciality(DoctorSpecalityVm doctorSpecalityvm)
        {
            DoctorSpecality doctorSpecality = new DoctorSpecality();
            doctorSpecality = mapper.Map<DoctorSpecality>(doctorSpecalityvm);
            doctorRepository.PostDoctorSpeciality(doctorSpecality);
        }
    }
}
