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
            x.HasData(
                [
                    new User
                    {
                        Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                        Email = "mnowerty69@gmail.com",
                        Role = UserRole.Admin,
                    },
                    new User
                    {
                        Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaab"),
                        Email = "nowak.mikolaj19@gmail.com",
                        Role = UserRole.Admin,
                    },
                    new User
                    {
                        Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaac"),
                        Email = "kubakowieski5151@gmail.com",
                        Role = UserRole.Admin,
                    },
                    new User
                    {
                        Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa5"),
                        Email = "jkowiesk@gmail.com",
                        Role = UserRole.Driver,
                    },
                    new User
                    {
                        Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaad"),
                        Email = "karol.orzechowski1337@gmail.com",
                        Role = UserRole.Admin,
                    },
                    new User
                    {
                        Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaae"),
                        Email = "waceg.qtasiks@gmail.com",
                        Role = UserRole.Admin,
                    },
                    new User
                    {
                        Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaf"),
                        Email = "tomsongra10201@gmail.com",
                        Role = UserRole.Admin,
                    },
                ]
            );
        });
    }
}
