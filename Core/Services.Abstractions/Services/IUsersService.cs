using UsersService.Core.Contracts.Dto;

namespace UsersService.Core.Services.Abstractions.Services;

public interface IUsersService
{
    Task<UserDto> GetUserById(Guid id);
    Task<UserDto> GetUserByEmail(string email);
    Task<UserDto> CreateUser(UserDto user);
    Task<Guid> UpdateUser(UserDto user);
    Task DeleteUser(UserDto user);
}
