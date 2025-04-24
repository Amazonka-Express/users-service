using Microsoft.EntityFrameworkCore;
using UsersService.Infrastructure.Persistence.RepositoryContext;

namespace Api.Extensions;

public static class ServiceCollectionExtensions
{
    private const string dbConnectionString = "ERSMS_POSTGRESQL_CONNECTION_STRING";

    public static void ConfigureDbContext(this IServiceCollection services)
    {
        services.AddDbContext<RepositoryContext>(options =>
        {
            options.UseNpgsql(
                Environment.GetEnvironmentVariable(dbConnectionString) ?? string.Empty,
                npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);
                    npgsqlOptions.CommandTimeout(60);
                }
            );
        });
    }
}
