using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthInspector.Data;
using HealthInspector.IRepository;
using HealthInspector.Models;
using HealthInspector.ViewModels;

namespace HealthInspector.Repository
{
    public class BmiRepository: IBmiRepository
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;

        public BmiRepository(IMapper mapper, ApplicationDbContext dbContext)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
        }

        public void PostUser(BmiViewModel bmiViewModel)
        {
            Bmi bmi = new Bmi();
            bmi = mapper.Map<Bmi>(bmiViewModel);

            dbContext.Bmis.Add(bmi);
            dbContext.SaveChanges();
        }
    }
}
