using AutoMapper;
using HealthInspector.Data;
using HealthInspector.IRepository;
using HealthInspector.Models;
using HealthInspector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext dbContext;
        

        public DoctorRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }

        public List<DoctorAvailability> GetDoctorAvailabilities(int id)
        {
            List<DoctorAvailability> doctorAvailabilities = new List<DoctorAvailability>();
            doctorAvailabilities = dbContext.DoctorAvailabilities.Where(m => m.UserId == id).ToList();
            return doctorAvailabilities;
        }

        public DoctorSpecality GetDoctorSpeciality(int id)
        {
            DoctorSpecality doctorSpecality = new DoctorSpecality();
            doctorSpecality = dbContext.DoctorSpecalities.FirstOrDefault(m => m.UserId == id);
            return doctorSpecality;
        }

        public void PostDoctorAvailability(DoctorAvailability doctorAvailability)
        {
            try
            {
                dbContext.DoctorAvailabilities.Add(doctorAvailability);
            }
            catch(Exception)
            {
                dbContext.DoctorAvailabilities.Update(doctorAvailability);
            }
            dbContext.SaveChanges();
        }

        public void PostDoctorSpeciality(DoctorSpecality doctorSpecality)
        {
            
            dbContext.DoctorSpecalities.Add(doctorSpecality);
            dbContext.SaveChanges();
        }
        public List<DoctorAvailability> GetDoctorAvailabilities()
        {
            List<DoctorAvailability> doctorAvailabilities = new List<DoctorAvailability>();
            doctorAvailabilities = dbContext.DoctorAvailabilities.ToList();
            return doctorAvailabilities;
        }

        public List<DoctorSpecality> GetDoctorSpecialities()
        {
            List<DoctorSpecality> doctorSpecality = new List<DoctorSpecality>();
            doctorSpecality = dbContext.DoctorSpecalities.ToList();
            return doctorSpecality;
        }

        public List<DoctorAvailability> GetDoctorAvailability(int id)
        {
            List<DoctorAvailability> doctorAvailabilities = new List<DoctorAvailability>();
            doctorAvailabilities = dbContext.DoctorAvailabilities.Where(m=>m.UserId==id).ToList();
            return doctorAvailabilities;
        }

        public DoctorAvailability GetDoctorAvailabilityById(int id)
        {
            DoctorAvailability doctorAvailability = new DoctorAvailability();
            doctorAvailability = dbContext.DoctorAvailabilities.FirstOrDefault(m => m.Id == id);
            return doctorAvailability;
        }

        
    }
}
