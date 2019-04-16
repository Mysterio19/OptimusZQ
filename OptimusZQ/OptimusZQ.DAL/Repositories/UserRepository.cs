using Microsoft.EntityFrameworkCore;
using OptimusZQ.DAL.Abstract;
using OptimusZQ.DAL.Models;
using System.Linq;

namespace OptimusZQ.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(OptimusDbContext dbContext) : base(dbContext)
        {
        }

        public User GetUserByLogin(string login)
                   => DbContext
                    .Set<User>()
                    .FirstOrDefault(user => user.Login == login);
        
    }
}
