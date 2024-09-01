using MyGolfApp.Authentication;
using MyGolfApp.Interfaces;
using MyGolfApp.Repository;
using MyGolfApp.Repository.Interfaces;
using MyGolfApp.Repository.Models;

namespace MyGolfApp.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    public UserService(IPasswordHasher passwordHasher, IUnitOfWork unitOfWork)
    {
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }
    
    public int Create(string email, string username, string password)
    {
        var now = DateTime.UtcNow;
        
        var user = new User()
        {
            Email = email,
            ModifiedDate = now,
            CreateDate = now,
            Username = username
        };
        
        var hashedPassword = _passwordHasher.EncryptPassword(user, password);
        user.Password = hashedPassword;

        _unitOfWork.Users.Add(user);
        var id = _unitOfWork.Complete();

        return id;
    }

    public IEnumerable<IUser> GetAll()
    {
        var users = _unitOfWork.Users.GetAll().ToList();
        return users;
    }
}