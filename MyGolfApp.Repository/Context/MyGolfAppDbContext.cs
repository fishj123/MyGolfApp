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

        // Fluent API configurations, if necessary
        // modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
    }
}