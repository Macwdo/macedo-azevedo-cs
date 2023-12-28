using AutoMapper;
using Ma.API.DTOs.Registry;
using Ma.API.Entities;

namespace Ma.API.Mapper;

public class RegistryProfile: Profile
{
    public RegistryProfile()
    {
        CreateMap<CreateRegistryDto, Registry>();
        CreateMap<ReadRegistryDto, Registry>();
        CreateMap<UpdateRegistryDto, Registry>();
        CreateMap<Registry, ReadRegistryDto>()
            .ForMember(
                dest => dest.LawyerResponsible,
                opt => opt.MapFrom(src => src.LawyerResponsible)
            );
    }
}