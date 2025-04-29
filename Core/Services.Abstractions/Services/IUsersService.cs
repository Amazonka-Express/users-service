using UsersService.Core.Contracts.Dto;

namespace UsersService.Core.Services.Abstractions.Services;

public interface IUsersService
{
    Task<UserDto> GetUserById(int id);
    Task<UserDto> GetUserByEmail(string email);
    Task<UserDto> CreateUser(UserDto user);
    Task UpdateUser(UserDto user);
    Task DeleteUser(UserDto user);
}
