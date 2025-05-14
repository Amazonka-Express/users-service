using AutoMapper;
using Core.Exceptions.Users;
using Core.Logger;
using Microsoft.EntityFrameworkCore;
using UsersService.Core.Contracts.Dto;
using UsersService.Core.Domain.Entities;
using UsersService.Core.Domain.Repositories;
using UsersService.Core.Services.Abstractions.Services;

namespace UsersService.Infrastructure.Services.Services;

public class UsersService : ServiceBase, IUsersService
{
    public UsersService(IRepositoryWrapper repositoryWrapper, IMapper mapper, ILoggerManager logger)
        : base(repositoryWrapper, mapper, logger) { }

    public async Task<UserDto?> CreateUser(UserDto userDto)
    {
        var user = await repositoryWrapper
            .Users.FindByCondition(x => x.Email == userDto.Email)
            .FirstOrDefaultAsync();

        if (user != null)
            return null;

        user = mapper.Map<User>(userDto);
        user.Role = mapper.Map<UserRole>(userDto.Role);
        repositoryWrapper.Users.Create(user);
        await repositoryWrapper.Save();
        return mapper.Map<UserDto>(user);
    }

    public async Task<bool> DeleteUser(string email)
    {
        var user = await repositoryWrapper
            .Users.FindByCondition(x => x.Email == email)
            .FirstOrDefaultAsync();

        if (user == null)
            return false;

        repositoryWrapper.Users.Delete(user);
        await repositoryWrapper.Save();
        return true;
    }

    public async Task<UserDto> GetUserByEmail(string email)
    {
        logger.LogInfo(nameof(GetUserByEmail), email);
        var user =
            await repositoryWrapper
                .Users.FindByCondition(x => x.Email == email)
                .FirstOrDefaultAsync() ?? throw new UserNotFoundException(email);

        return mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetUserById(Guid id)
    {
        logger.LogInfo(nameof(GetUserById), id.ToString());
        var user =
            await repositoryWrapper
                .Users.FindByCondition(x => x.Id.Equals(id))
                .FirstOrDefaultAsync() ?? throw new UserNotFoundException(id.ToString());

        return mapper.Map<UserDto>(user);
    }

    public async Task<(UserDto user, bool isNewUser)> TryUpdateUser(UserDto userDto)
    {
        var foundUser =
            await repositoryWrapper
                .Users.FindByCondition(x => x.Email == userDto.Email)
                .FirstOrDefaultAsync()
            ?? throw new AccountCreationRestrictedException(userDto.Email);

        var isNewUser =
            string.IsNullOrWhiteSpace(foundUser.FirstName)
            || string.IsNullOrWhiteSpace(foundUser.LastName);

        User updatedUser;
        if (
            !string.IsNullOrWhiteSpace(userDto.FirstName)
                && foundUser.FirstName != userDto.FirstName
            || !string.IsNullOrWhiteSpace(userDto.LastName)
                && foundUser.LastName != userDto.LastName
        )
        {
            updatedUser = mapper.Map(userDto, foundUser);
            repositoryWrapper.Users.Update(updatedUser);
            await repositoryWrapper.Save();
        }
        else
            updatedUser = foundUser;

        return (mapper.Map<UserDto>(updatedUser), isNewUser);
    }
}
