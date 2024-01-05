using AutoMapper;
using Ma.API.Entities;
using Ma.API.Models.Lawyer;

namespace Ma.API.Mapper;

public class LawyerProfile: Profile
{

    public LawyerProfile()
    {

        CreateMap<CreateLawyerDto, Lawyer>();
        CreateMap<ReadLawyerDto, Lawyer>();
        CreateMap<Lawyer, ReadLawyerDto>()
            .ForMember(
                dest => dest.User,
                opt => opt.MapFrom(src => src.User));
        CreateMap<UpdateLawyerDto, Lawyer>();

    }
}