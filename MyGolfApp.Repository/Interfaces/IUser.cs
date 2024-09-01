namespace MyGolfApp.Repository.Interfaces;

public interface IUser
{
    int Id { get; set; }
    string Email { get; set; }
    string Password { get; set; }
    string Username { get; set; }
    DateTime CreateDate { get; set; }
    DateTime ModifiedDate { get; set; }
}