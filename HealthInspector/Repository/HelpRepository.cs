using HealthInspector.Data;
using HealthInspector.IRepository;
using HealthInspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.Repository
{
    public class HelpRepository : IHelpRepository
    {
        private readonly ApplicationDbContext _db;
        public HelpRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateHelp(Help help)
        {
            _db.Helps.Add(help);
            return Save();
        }

        public Help GetHelp(int Id)
        {
            return _db.Helps.FirstOrDefault(a => a.Id == Id);
        }

        public ICollection<Help> GetHelps()
        {
            return _db.Helps.OrderBy(a => a.UserId).ToList();
        }

        public bool HelpExists(string UserId)
        {
            User user = new User();
            user = _db.Users.FirstOrDefault(m => m.UserId == UserId);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateHelp(Help help)
        {
            _db.Helps.Update(help);
            return Save();
        }
    }
}
