using Microsoft.EntityFrameworkCore;
using UsersService.Core.Domain.Entities;

namespace UsersService.Infrastructure.Persistence.RepositoryContext;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(x =>
        {
            x.HasKey(u => u.Id);
            x.Property(u => u.Email).IsRequired();
        });
    }
}
