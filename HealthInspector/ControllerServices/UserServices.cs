using HealthInspector.IControllerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.ControllerServices
{
    public class UserServices : IUserServices
    {
        public string GetUserId(string name, string phoneNumber)
        {
            return name.Substring(0, 3) + phoneNumber.Substring(0, 3);
        }
    }
}
