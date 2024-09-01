using MyGolfApp.Interfaces;

namespace MyGolfApp.Models;

public class UserResponse : IUserPublic, IUserMetadata
{
    public string Email { get; set; }
    public string Username { get; set; }
    public DateTime ModifiedDate { get; set; }
    public DateTime CreateDate { get; set; }
}