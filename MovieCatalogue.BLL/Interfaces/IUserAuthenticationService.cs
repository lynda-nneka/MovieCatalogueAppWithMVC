using System;
using System.Net.NetworkInformation;
using MovieCatalogue.BLL.Models;

namespace MovieCatalogue.BLL.Interfaces
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Task<Status> RegisterAsync(RegistrationModel model);
    }
}

