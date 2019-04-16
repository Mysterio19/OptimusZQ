﻿using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OptimusZQ.DAL.Abstract;
using OptimusZQ.DAL.Models;
using OptimusZQ.Services.Abstract;
using OptimusZQ.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OptimusZQ.Services.Concrete
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        private IUserRepository _userRepository;
        private LoginModel _user;
        private readonly IMapper _mapper;

        public AuthenticationService(IUserRepository userRepository, IOptions<AppSettings> options, IMapper mapper) : base(options)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public LoginModel GetUserByUserLogin(string userLogin)
        {
            return _mapper.Map<LoginModel>(_userRepository.GetUserByLogin(userLogin));
        }

        public bool HasUser(string userLogin)
        {
            _user = GetUserByUserLogin(userLogin);
            return _user == null ? false : true;
        }

        public string LogIn(string userLogin, string password)
        {
            var paswordIsCorrect = _user.Password.Equals(password);

            if (paswordIsCorrect)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.SecretKey));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signinCredentials
                );

                return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            }
            return null;
        }

        public string RegisterUser(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
