using AutoMapper;
using Core.Logger;
using UsersService.Core.Contracts.Dto;
using UsersService.Core.Domain.Repositories;
using UsersService.Core.Services.Abstractions.Services;

namespace UsersService.Infrastructure.Services.Services;

public class UsersService : ServiceBase, IUsersService
{
    public UsersService(IRepositoryWrapper repositoryWrapper, IMapper mapper, ILoggerManager logger)
        : base(repositoryWrapper, mapper, logger) { }

    public Task<UserDto> CreateUser(UserDto user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUser(UserDto user)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateUser(UserDto user)
    {
        throw new NotImplementedException();
    }
}
