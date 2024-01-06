using AutoMapper;
using Ma.API.Entities;
using Ma.API.Models.User;

namespace Ma.API.Mapper;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<ReadUserDto, UserEntity>();
        CreateMap<UserEntity, ReadUserDto>();
    }
}