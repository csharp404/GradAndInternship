using AutoMapper;
using GradAndInternship.Dtos;
using GradAndInternship.Models;

namespace GradAndInternship.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProposalDto, ProjectDetails>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
            .ForMember(dest => dest.Objective, opt => opt.MapFrom(src => src.Objective))
            .ForMember(dest => dest.TimeLine, opt => opt.MapFrom(src => src.TimeLine))
            .ForMember(dest => dest.Student, opt => opt.Ignore()) // Handled separately
            .ForMember(dest => dest.Tasks, opt => opt.Ignore()); // Handled separately

        // Task to Chart Mapping
        CreateMap<TasksDto, Chart>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.StarTime, opt => opt.MapFrom(src => src.StarTime))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime));

    }
}