using HealthInspector.Data;
using HealthInspector.IRepository;
using HealthInspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AppointmentRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Approve(int id)
        {
            Appointment appointment = new Appointment();
            appointment = dbContext.Appointments.FirstOrDefault(m => m.Id == id);
            appointment.Status = "Approved";
            dbContext.Appointments.Update(appointment);
            dbContext.SaveChanges();
        }
        public void Reject(int id)
        {
            Appointment appointment = new Appointment();
            appointment = dbContext.Appointments.FirstOrDefault(m => m.Id == id);
            appointment.Status = "Rejected";
            dbContext.Appointments.Update(appointment);
            dbContext.SaveChanges();
        }
        public List<Appointment> GetAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            appointments = dbContext.Appointments.Where(m=>m.Status== "Registered").ToList();
            return appointments;
        }
        public List<Appointment> GetApprovedAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();
            appointments = dbContext.Appointments.Where(m => m.Status == "Approved").ToList();
            return appointments;
        }

        public void PostAppointment(Appointment appointment)
        {
            dbContext.Appointments.Add(appointment);
            dbContext.SaveChanges();
        }

        public List<Appointment> GetAppointmentsForUser(int id)
        {
            List<Appointment> appointments = new List<Appointment>();
            appointments = dbContext.Appointments.Where(m => m.UserId == id).ToList();
            return appointments;
        }

        public Appointment GetAppointment(int id)
        {
            Appointment appointment = new Appointment();
            appointment = dbContext.Appointments.FirstOrDefault(m => m.Id == id);
            return appointment;
        }
    }
}
