using AutoMapper;
using Ma.API.Entities;
using Ma.API.Models.Registry;

namespace Ma.API.Mapper;

public class RegistryProfile: Profile
{
    public RegistryProfile()
    {
        CreateMap<CreateRegistryDto, RegistryEntity>();
        CreateMap<ReadRegistryDto, RegistryEntity>();
        CreateMap<UpdateRegistryDto, RegistryEntity>();
        CreateMap<RegistryEntity, ReadRegistryDto>()
            .ForMember(
                dest => dest.LawyerResponsible,
                opt => opt.MapFrom(src => src.LawyerResponsible)
            );
    }
}