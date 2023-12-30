using AutoMapper;
using Ma.API.Entities;
using Ma.API.Models.Lawyer;

namespace Ma.API.Mapper;

public class LawyerProfile: Profile
{

    public LawyerProfile()
    {

        CreateMap<ReadLawyerDto, Lawyer>();
        CreateMap<Lawyer, ReadLawyerDto>();
    }
}