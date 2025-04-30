using UsersService.Core.Contracts.Dto;

namespace Api.Helpers;

internal static class RpcMapper
{
    public static User.User Map(this UserDto user)
    {
        return new User.User()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = user.Role.ToString(),
        };
    }

    public static UserDto Map(this User.UserMetadata user)
    {
        return new UserDto()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
        };
    }
}
