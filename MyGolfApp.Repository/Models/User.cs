using MyGolfApp.Repository.Interfaces;

namespace MyGolfApp.Repository.Models;

public class User : IUser
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}