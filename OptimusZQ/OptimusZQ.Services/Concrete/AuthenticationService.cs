using Microsoft.IdentityModel.Tokens;
using OptimusZQ.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OptimusZQ.Services.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool HasUser(string userName)
        {
            throw new NotImplementedException();
        }

        public string LogIn(string userName, string password)
        {

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["secretKey"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }

        public string RegisterUser(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
