using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.IControllerServices
{
    public interface IUserServices
    {
        string GetUserId(string name,string phoneNumber);
    }
}
