using HealthInspector.Data;
using HealthInspector.IRepository;
using HealthInspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Repository
{
    public class TreatementRepository : ITreatementRepository
    {
        private readonly ApplicationDbContext dbContext;

        public TreatementRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Treatment GetTreatementByAppointmentId(int id)
        {
            Treatment treatment = new Treatment();
            treatment = dbContext.Treatments.FirstOrDefault(m => m.AppointmentId == id);
            return treatment;
        }

        public Treatment GetTreatementById(int id)
        {
            Treatment treatment = new Treatment();
            treatment = dbContext.Treatments.FirstOrDefault(m => m.Id == id);
            return treatment;

        }

        public List<Treatment> GetTreatements()
        {
            List<Treatment> treatments = new List<Treatment>();
            treatments = dbContext.Treatments.ToList();
            return treatments;
        }

        public string LastPatientId(string first)
        {
            Treatment treatment = new Treatment();
            treatment = dbContext.Treatments.Where(m => m.PatientId.StartsWith(first)).OrderByDescending(m => m.PatientId).FirstOrDefault();
            if(treatment==null)
            {
                return null;
            }
            return treatment.PatientId;
        }

        public void PostTreatement(Treatment treatment)
        {
            dbContext.Treatments.Add(treatment);
            dbContext.SaveChanges();
        }

        public void UpdateTreatement(Treatment treatment)
        {
            dbContext.Treatments.Update(treatment);
            dbContext.SaveChanges();
        }
    }
}
