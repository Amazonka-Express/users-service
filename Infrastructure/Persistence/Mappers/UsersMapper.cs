using UsersService.Core.Contracts.Dto;
using UsersService.Core.Domain.Entities;

namespace UsersService.Infrastructure.Persistence.Mappers;

public class UsersMapper : AutoMapper.Profile
{
    public UsersMapper()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>()
            .ForMember(
                x => x.FirstName,
                opt => opt.Condition(src => !string.IsNullOrWhiteSpace(src.FirstName))
            )
            .ForMember(
                x => x.LastName,
                opt => opt.Condition(src => !string.IsNullOrWhiteSpace(src.LastName))
            )
            .ForMember(dest => dest.Role, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<UserRole, UserRoleDto>()
            .ConvertUsing(src => Enum.Parse<UserRoleDto>(src.ToString()));
        CreateMap<UserRoleDto, UserRole>()
            .ConvertUsing(src => Enum.Parse<UserRole>(src.ToString()));
    }
}
