using Api.Middleware;
using Core.Logger;
using Microsoft.EntityFrameworkCore;
using NLog;
using UsersService.Core.Domain.Repositories;
using UsersService.Core.Services.Abstractions.Services;
using UsersService.Infrastructure.Persistence.Repositories;
using UsersService.Infrastructure.Persistence.RepositoryContext;
using UsersService.Infrastructure.Services;

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

    public static void ConfigureExceptionMiddleware(this IServiceCollection services)
    {
        services.AddTransient<ExceptionInterceptor>();
        services.AddGrpc(options =>
        {
            options.Interceptors.Add<ExceptionInterceptor>();
        });
    }

    public static void ConfigureServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
    }

    public static void ConfigureRepositoryWrapper(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }

    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
