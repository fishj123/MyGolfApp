
using MyGolfApp.Interfaces;

namespace MyGolfApp.Models;

public class UserCreate : IUserPublic
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
}