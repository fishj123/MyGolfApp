using Microsoft.EntityFrameworkCore;
using MyGolfApp.Repository.Models;

namespace MyGolfApp.Repository.Context;

public class MyGolfAppDbContext : DbContext
{
    // Constructor
    public MyGolfAppDbContext(DbContextOptions<MyGolfAppDbContext> options)
        : base(options)
    {
    }

    // DbSet properties for your entities
    public DbSet<User> Users { get; set; }

    // Optional: OnModelCreating method to configure your model
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Specify the table name as singular
        modelBuilder.Entity<User>().ToTable("User");
    }
}