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
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IUserRepository userRepository;
        private readonly ITreatementRepository treatementRepository;

        public DoctorServices(ITreatementRepository treatementRepository,IUserRepository userRepository,IDoctorRepository doctorRepository, IMapper mapper,IClinicRepository clinicRepository, IAppointmentRepository appointmentRepository)
        {
            this.treatementRepository = treatementRepository;
            this.doctorRepository = doctorRepository;
            this.mapper = mapper;
            this.clinicRepository = clinicRepository;
            this.appointmentRepository = appointmentRepository;
            this.userRepository = userRepository;
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

        public List<AppointmentDataVm> GetAppointmentDetails(int id)
        {
            List<User> users = new List<User>();
            users = userRepository.GetPatients();

            List<DoctorAvailability> doctorAvailabilities = new List<DoctorAvailability>();
            doctorAvailabilities = doctorRepository.GetDoctorAvailability(id);

            List<Clinic> clinics = new List<Clinic>();
            clinics = clinicRepository.GetClinics();

            List<Appointment> appointments = new List<Appointment>();
            appointments = appointmentRepository.GetAppointments();

            List<AppointmentDataVm> appointmentDataVms = new List<AppointmentDataVm>();

            var result = (from appointment in appointments
                          join user in users on appointment.UserId equals user.Id
                          join avail in doctorAvailabilities on appointment.DoctorAvailabilityId equals avail.Id
                          join clinic in clinics on avail.ClinicId equals clinic.Id
                          select new
                          {
                              Id=appointment.Id,
                              PatientName=user.FirstName+" "+user.LastName,
                              ClinicName=clinic.ClinicName,
                              Date=appointment.AppointmentDate,
                              Message=appointment.Message,
                              Dob=user.Dob,
                              Gender=user.Gender
                          });

            foreach(var obj in result)
            {
                AppointmentDataVm appointmentDataVm = new AppointmentDataVm()
                {
                    Id = obj.Id,
                    PatientName = obj.PatientName,
                    ClinicName = obj.ClinicName,
                    Date = obj.Date,
                    Message = obj.Message,
                    Age = DateTime.Now.Year - obj.Dob.Year,
                    Gender=obj.Gender
                };
                appointmentDataVms.Add(appointmentDataVm);
            }
            return appointmentDataVms;
        }
        public List<AppointmentDataVm> GetApprovedAppointmentDetails(int id)
        {
            List<User> users = new List<User>();
            users = userRepository.GetPatients();

            List<DoctorAvailability> doctorAvailabilities = new List<DoctorAvailability>();
            doctorAvailabilities = doctorRepository.GetDoctorAvailability(id);

            List<Clinic> clinics = new List<Clinic>();
            clinics = clinicRepository.GetClinics();

            List<Appointment> appointments = new List<Appointment>();
            appointments = appointmentRepository.GetApprovedAppointments();

            List<AppointmentDataVm> appointmentDataVms = new List<AppointmentDataVm>();

            var result = (from appointment in appointments
                          join user in users on appointment.UserId equals user.Id
                          join avail in doctorAvailabilities on appointment.DoctorAvailabilityId equals avail.Id
                          join clinic in clinics on avail.ClinicId equals clinic.Id
                          select new
                          {
                              Id = appointment.Id,
                              PatientName = user.FirstName + " " + user.LastName,
                              ClinicName = clinic.ClinicName,
                              Date = appointment.AppointmentDate,
                              Message = appointment.Message,
                              Dob = user.Dob,
                              Gender = user.Gender
                          });

            foreach (var obj in result)
            {
                AppointmentDataVm appointmentDataVm = new AppointmentDataVm()
                {
                    Id = obj.Id,
                    PatientName = obj.PatientName,
                    ClinicName = obj.ClinicName,
                    Date = obj.Date,
                    Message = obj.Message,
                    Age = DateTime.Now.Year - obj.Dob.Year,
                    Gender = obj.Gender
                };
                appointmentDataVms.Add(appointmentDataVm);
            }
            return appointmentDataVms;
        }

        public void GeneratePatientRecord(int id)
        {
            Appointment appointment = new Appointment();
            appointment = appointmentRepository.GetAppointment(id);

            DoctorAvailability doctorAvailability = new DoctorAvailability();
            doctorAvailability = doctorRepository.GetDoctorAvailabilityById(appointment.DoctorAvailabilityId);

            Clinic clinic = new Clinic();
            clinic = clinicRepository.GetClinic(doctorAvailability.ClinicId);
            Treatment treatment = new Treatment();
            treatment.AppointmentId = appointment.Id;

            string patientId = treatementRepository.LastPatientId(clinic.ClinicName.Substring(0, 3));

            if(patientId==null)
            {
                
                treatment.PatientId = clinic.ClinicName.Substring(0, 3) + "0001";
            }
            else
            {
                int num = int.Parse(patientId.Substring(3, 4));
                num = num + 1;
                treatment.PatientId = clinic.ClinicName.Substring(0, 3) + num.ToString().PadLeft(4, '0');
            }

            treatementRepository.PostTreatement(treatment);
        }

        public List<Treatment> GetPatientIdList(int v)
        {
            List<Treatment> treatments=new List<Treatment>();
            List<Treatment> treatments2=new List<Treatment>();
            List<Appointment> appointments = new List<Appointment>();
            List<DoctorAvailability> availabilities = new List<DoctorAvailability>();

            treatments = treatementRepository.GetTreatements();
            appointments = appointmentRepository.GetApprovedAppointments();
            availabilities = doctorRepository.GetDoctorAvailabilities();

            var result = (from treatement in treatments
                          join appointment in appointments on treatement.AppointmentId equals appointment.Id
                          join availability in availabilities on appointment.DoctorAvailabilityId equals availability.Id
                          where availability.UserId == v
                          select new {
                              Id=treatement.Id,
                              PatientId=treatement.PatientId,
                              AppointmentId =treatement.AppointmentId
            });

            foreach(var obj in result)
            {
                Treatment treatment = new Treatment()
                {
                    Id = obj.Id,
                    PatientId = obj.PatientId,
                    AppointmentId = obj.AppointmentId
                };
                treatments2.Add(treatment);
            }
            return treatments2;
            
        }
    }
}
