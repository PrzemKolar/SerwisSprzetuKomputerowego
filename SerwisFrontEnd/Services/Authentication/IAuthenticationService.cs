using SerwisFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerwisFrontEnd.Services.Authentication
{
    public interface IAuthenticationService
    {
        User User { get; }
        Task Initialize();
        Task Login(string username, string password);
        Task Logout();
    }
}
