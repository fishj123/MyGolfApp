using MyGolfApp.Repository.Models;

namespace MyGolfApp.Repository;

public interface IUserRepository : IRepository<User>
{
    User GetByEmail(string email);
}