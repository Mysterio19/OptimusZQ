using System;
using System.Collections.Generic;
using System.Text;

namespace OptimusZQ.Services.Abstract
{
    public interface IAuthenticationService
    {
        bool HasUser(string userName);

        string LogIn(string userName, string password);

    }
}
