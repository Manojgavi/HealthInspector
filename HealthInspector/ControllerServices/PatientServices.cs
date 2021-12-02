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
    public class PatientServices : IPatientServices
    {
        private readonly IDoctorRepository doctorRepository;
       
        private readonly IClinicRepository clinicRepository;
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IUserRepository userRepository;

        public PatientServices(IUserRepository userRepository, IDoctorRepository doctorRepository, IClinicRepository clinicRepository, IAppointmentRepository appointmentRepository)
        {
            this.doctorRepository = doctorRepository;
            
            this.clinicRepository = clinicRepository;
            this.appointmentRepository = appointmentRepository;
            this.userRepository = userRepository;
        }
        public List<StatusDataViewModel> GetStatusForUser(int id)
        {
            List<User> users = new List<User>();
            users = userRepository.GetDoctors();

            List<DoctorAvailability> doctorAvailabilities = new List<DoctorAvailability>();
            doctorAvailabilities = doctorRepository.GetDoctorAvailabilities();

            List<Clinic> clinics = new List<Clinic>();
            clinics = clinicRepository.GetClinics();

            List<Appointment> appointments = new List<Appointment>();
            appointments = appointmentRepository.GetAppointmentsForUser(id);

            List<StatusDataViewModel> appointmentDataVms = new List<StatusDataViewModel>();

            var result = (from appointment in appointments
                          
                          join avail in doctorAvailabilities on appointment.DoctorAvailabilityId equals avail.Id
                          join user in users on avail.UserId equals user.Id
                          join clinic in clinics on avail.ClinicId equals clinic.Id
                          select new
                          {
                              Id = appointment.Id,
                              DoctorName = user.FirstName + " " + user.LastName,
                              ClinicName = clinic.ClinicName,
                              Date = appointment.AppointmentDate,
                              Message = appointment.Message,
                              Status=appointment.Status
                          });

            foreach (var obj in result)
            {
                StatusDataViewModel appointmentDataVm = new StatusDataViewModel()
                {
                    Id = obj.Id,
                    DoctorName = obj.DoctorName,
                    ClinicName = obj.ClinicName,
                    Date = obj.Date,
                    Message = obj.Message,
                    Status=obj.Status
                };
                appointmentDataVms.Add(appointmentDataVm);
            }
            return appointmentDataVms;
        }
    

    }
}
