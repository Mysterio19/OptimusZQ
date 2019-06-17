using AutoMapper;
using OptimusZQ.DAL.Models;
using OptimusZQ.Services.Dtos;

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
