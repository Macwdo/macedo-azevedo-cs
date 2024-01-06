using AutoMapper;
using Ma.API.Entities;
using Ma.API.Models.Lawyer;

namespace Ma.API.Mapper;

public class LawyerProfile: Profile
{

    public LawyerProfile()
    {

        CreateMap<CreateLawyerDto, LawyerEntity>();
        CreateMap<ReadLawyerDto, LawyerEntity>();
        CreateMap<LawyerEntity, ReadLawyerDto>()
            .ForMember(
                dest => dest.User,
                opt => opt.MapFrom(src => src.User));
        CreateMap<UpdateLawyerDto, LawyerEntity>();

    }
}