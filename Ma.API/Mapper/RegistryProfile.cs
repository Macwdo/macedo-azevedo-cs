using AutoMapper;
using Ma.API.Entities;
using Ma.API.Models.Registry;

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