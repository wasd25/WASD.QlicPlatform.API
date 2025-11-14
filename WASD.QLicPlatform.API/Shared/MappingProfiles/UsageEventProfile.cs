using AutoMapper;
using WASD.QLicPlatform.API.UsageManagement.Domain.Models;
using WASD.QLicPlatform.API.UsageManagement.Application.DTOs;

namespace WASD.QLicPlatform.API.Shared.MappingProfiles;

public class UsageEventProfile : Profile
{
    public UsageEventProfile()
    {
        // Entity -> DTO
        CreateMap<UsageEvent, UsageEventDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time.ToString("HH:mm")));

        // DTO -> Entity
        CreateMap<UsageEventDto, UsageEvent>()
            .ConstructUsing(dto => new UsageEvent(
                DateTime.ParseExact(dto.Time, "HH:mm", null),
                dto.Amount,
                dto.Source
            ));
    }
}