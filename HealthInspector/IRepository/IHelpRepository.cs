using HealthInspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.IRepository
{
    public interface IHelpRepository
    {
        ICollection<Help> GetHelps();
        Help GetHelp(int Id);
        bool HelpExists(string UserId);
        bool CreateHelp(Help help);
        bool UpdateHelp(Help help);
        bool Save();
    }
}
