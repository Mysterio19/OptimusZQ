using Microsoft.EntityFrameworkCore;
using OptimusZQ.DAL.Models;
namespace OptimusZQ.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(OptimusDbContext dbContext) : base(dbContext)
        {
        }
    }
}
