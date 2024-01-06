using AutoMapper;
using Ma.API.Entities.Lawsuit;
using Ma.API.Models.Lawsuit;

namespace Ma.API.Mapper;

public class LawsuitProfile: Profile
{

    public LawsuitProfile()
    {
        CreateMap<CreateLawsuitDto, LawsuitEntity>();
        CreateMap<ReadLawsuitDto, LawsuitEntity>();
        CreateMap<LawsuitEntity, ReadLawsuitDto>()
            .ForMember(
                dest => dest.ResponsibleLawyer,
                opt => opt.MapFrom(src => src.ResponsibleLawyer)
            )
            .ForMember(
                dest => dest.Client,
                opt => opt.MapFrom(src => src.Client)
            )
            .ForMember(
                dest => dest.AdversePart,
                opt => opt.MapFrom(src => src.AdversePart)
            )
            .ForMember(
                dest => dest.IndicatedBy,
                opt => opt.MapFrom(src => src.IndicatedBy)
            )
            ;
        CreateMap<UpdateLawsuitDto, LawsuitEntity>();

    }
}