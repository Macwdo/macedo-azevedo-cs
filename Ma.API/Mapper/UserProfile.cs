using AutoMapper;
using Ma.API.DTOs.User;
using Ma.API.Entities;

namespace Ma.API.Mapper;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<ReadUserDto, User>();
        CreateMap<User, ReadUserDto>();
    }
}