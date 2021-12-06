using HealthInspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.IRepository
{
    public interface IAppointmentRepository
    {
        void PostAppointment(Appointment appointment);
        List<Appointment> GetAppointments();
        void Reject(int id);
        void Approve(int id);
        List<Appointment> GetAppointmentsForUser(int id);
        Appointment GetAppointment(int id);
        List<Appointment> GetApprovedAppointments();
    }
}
