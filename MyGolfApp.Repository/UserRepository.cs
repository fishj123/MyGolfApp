using Microsoft.EntityFrameworkCore;
using MyGolfApp.Repository.Context;
using MyGolfApp.Repository.Models;

namespace MyGolfApp.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public User GetByEmail(string email)
    {
        return Context.Users.FirstOrDefault(x => x.Email == email);
    }

    public MyGolfAppDbContext Context => DbContext as MyGolfAppDbContext;
}