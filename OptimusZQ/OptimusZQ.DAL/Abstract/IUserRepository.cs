using OptimusZQ.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OptimusZQ.DAL.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByLogin(string login);
    }
}
