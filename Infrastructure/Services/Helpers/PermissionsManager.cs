using Core.Logger;

namespace UsersService.Infrastructure.Services.Helpers;

public class PermissionsManager(ILoggerManager loggerManager)
{
    private readonly ILoggerManager logger = loggerManager;
}
