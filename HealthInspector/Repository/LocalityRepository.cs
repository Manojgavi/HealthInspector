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
    public class LocalityRepository : ILocalityRepository
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;
        public LocalityRepository(IMapper mapper,ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;

        }
        public List<Locality> GetLocalities()
        {
            List<Locality> localities = new List<Locality>();
            localities = dbContext.Localities.ToList();
            return localities;
        }

        public Locality GetLocality(int id)
        {
            Locality locality = new Locality();
            locality = dbContext.Localities.FirstOrDefault(m => m.Id == id);
            return locality;
        }

        public bool postLocality(Locality locality)
        {
            try
            {
                dbContext.Localities.Add(locality);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
            
    }
}
