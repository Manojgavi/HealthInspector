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
        public string LastPatientId(string first)
        {
            Treatment treatment = new Treatment();
            treatment = dbContext.Treatments.Where(m => m.PatientId.StartsWith(first)).OrderByDescending(m => m.PatientId).FirstOrDefault();
            return treatment.PatientId;
        }

        public void PostTreatement(Treatment treatment)
        {
            dbContext.Treatments.Add(treatment);
            dbContext.SaveChanges();
        }
    }
}
