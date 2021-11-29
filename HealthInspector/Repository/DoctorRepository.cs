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
        private readonly IMapper mapper;

        public DoctorRepository(ApplicationDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void PostDoctorAvailability(DoctorAvailability doctorAvailability)
        {
            dbContext.DoctorAvailabilities.Add(doctorAvailability);
            dbContext.SaveChanges();
        }

        public void PostDoctorSpeciality(DoctorSpecalityVm doctorSpecalityvm)
        {
            DoctorSpecality doctorSpecality = new DoctorSpecality();
            doctorSpecality = mapper.Map<DoctorSpecality>(doctorSpecalityvm);
            dbContext.DoctorSpecalities.Add(doctorSpecality);
            dbContext.SaveChanges();
        }
    }
}
