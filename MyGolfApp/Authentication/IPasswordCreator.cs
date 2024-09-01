using Microsoft.AspNetCore.Identity;
using MyGolfApp.Repository.Interfaces;
using MyGolfApp.Repository.Models;

namespace MyGolfApp.Authentication;

public interface IPasswordHasher
{
    string EncryptPassword(IUser user, string plainTextPassword);
    bool VerifyHashedPassword(IUser user, string encryptedPassword, string providedPassword);
}

public class MyPasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<IUser> _hasher;
    public MyPasswordHasher(PasswordHasher<IUser> hasher)
    {
        _hasher = hasher;
    }
    
    public string EncryptPassword(IUser user, string plainTextPassword)
    {
        try
        {
            return _hasher.HashPassword(user, plainTextPassword);
        }
        catch (Exception ex)
        {
            throw new Exception("Error in base64Encode" + ex.Message);
        }
    }
    
    public bool VerifyHashedPassword(IUser user, string encryptedPassword, string providedPassword)
    {
        var result = _hasher.VerifyHashedPassword(user, encryptedPassword, providedPassword);
        return result == PasswordVerificationResult.Success;
    }
}