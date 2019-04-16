using OptimusZQ.DAL.Models;
using OptimusZQ.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OptimusZQ.Services.Abstract
{
    public interface IAuthenticationService
    {
        bool HasUser(string login);

        string LogIn(string login, string password);

        string RegisterUser(string login, string password);

        LoginModel GetUserByUserLogin(string userLogin);

    }
}
