namespace MyGolfApp.Interfaces;

public interface IUserMetadata
{
    DateTime ModifiedDate { get; set; }
    DateTime CreateDate { get; set; }
}