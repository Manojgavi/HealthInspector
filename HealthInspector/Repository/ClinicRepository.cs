using AutoMapper;
using HealthInspector.Data;
using HealthInspector.IRepository;
using HealthInspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Repository
{
    public class ClinicRepository:IClinicRepository
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;
        public ClinicRepository(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public Clinic GetClinic(int Id)
        {
            Clinic clinic = new Clinic();
            clinic = dbContext.Clinics.FirstOrDefault(m => m.Id == Id);
            return clinic;
        }

        public List<Clinic> GetClinics()
        {
            List<Clinic> clinics = new List<Clinic>();
            clinics = dbContext.Clinics.ToList();
            return clinics;
        }

        public void PostClinic(Clinic Clinic)
        {
            dbContext.Clinics.Add(Clinic);
            dbContext.SaveChanges();
        }
    }
}
