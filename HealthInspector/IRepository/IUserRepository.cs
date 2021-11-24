using HealthInspector.Models;
using HealthInspector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInspector.IRepository
{
    public interface IUserRepository
    {
        string PostUser(UserViewModel userViewModel);
        bool UserExists(string userId);
        bool UserExists(string userId, string password);
        string GetRole(string userId);
        

    }
}
