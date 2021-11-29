using HealthInspector.Data;
using HealthInspector.IRepository;
using HealthInspector.Models;
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

        public void PostDoctorAvailability(DoctorAvailability doctorAvailability)
        {
            dbContext.DoctorAvailabilities.Add(doctorAvailability);
            dbContext.SaveChanges();
        }

        public void PostDoctorSpeciality(DoctorSpecality doctorSpecality)
        {
            dbContext.DoctorSpecalities.Add(doctorSpecality);
            dbContext.SaveChanges();
        }
    }
}
