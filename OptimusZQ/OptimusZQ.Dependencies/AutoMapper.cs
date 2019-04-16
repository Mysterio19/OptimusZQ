using AutoMapper;
using OptimusZQ.DAL.Models;
using OptimusZQ.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OptimusZQ.Dependencies
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, LoginModel>();
        }
    }
}
