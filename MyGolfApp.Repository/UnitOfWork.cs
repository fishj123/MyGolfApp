using MyGolfApp.Repository.Context;

namespace MyGolfApp.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyGolfAppDbContext _dbContext;
    
    public UnitOfWork(MyGolfAppDbContext dbContext)
    {
        _dbContext = dbContext;
        Users = new UserRepository(_dbContext);
    }
    
    public IUserRepository Users { get; } // decoupled Users from EF
    
    public int Complete()
    {
        return _dbContext.SaveChanges();
    }
    
    public void Dispose()
    {
        _dbContext.Dispose();
    }

}