using UsersService.Core.Contracts.Dto;

namespace UsersService.Core.Services.Abstractions.Services;

public interface IUsersService
{
    Task<UserDto> GetUserById(Guid id);
    Task<UserDto> GetUserByEmail(string email);
    Task<UserDto?> CreateUser(UserDto user);
    Task<(UserDto user, bool isNewUser)> TryUpdateUser(UserDto user);
    Task<bool> DeleteUser(string email);
}
