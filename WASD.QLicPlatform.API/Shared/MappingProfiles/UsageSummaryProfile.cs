using AutoMapper;
using WASD.QLicPlatform.API.UsageManagement.Domain.Models;
using WASD.QLicPlatform.API.UsageManagement.Application.DTOs;

namespace WASD.QLicPlatform.API.Shared.MappingProfiles;

public class UsageSummaryProfile : Profile
{
    public UsageSummaryProfile()
    {
        // Entity -> DTO
        CreateMap<UsageSummary, UsageSummaryDto>();

        // DTO -> Entity
        CreateMap<UsageSummaryDto, UsageSummary>()
            .ConstructUsing(dto => new UsageSummary(dto.Current, dto.DailyLimit, dto.MonthlyTotal));
    }
}