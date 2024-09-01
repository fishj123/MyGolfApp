namespace MyGolfApp.Repository;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    int Complete();
}