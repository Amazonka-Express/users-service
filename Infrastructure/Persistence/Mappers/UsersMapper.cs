using UsersService.Core.Contracts.Dto;
using UsersService.Core.Domain.Entities;

namespace UsersService.Infrastructure.Persistence.Mappers;

public class UsersMapper : AutoMapper.Profile
{
    public UsersMapper()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
    }
}
