using Core.Logger;
using Microsoft.EntityFrameworkCore;
using NLog;
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

    public static void ConfigureLogger(
        this IServiceCollection services,
        ConfigurationManager configuration
    )
    {
        NLog.Common.InternalLogger.LogLevel = NLog.LogLevel.Trace;

        var userProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        NLog.Common.InternalLogger.LogFile = string.Concat(
            userProfilePath,
            configuration.GetSection("NLog").GetValue<string>("internalLogFile")
        );

        LogManager
            .Setup()
            .LoadConfigurationFromFile(
                string.Concat(Directory.GetCurrentDirectory(), "/Logger/nlog.config")
            );

        services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}
