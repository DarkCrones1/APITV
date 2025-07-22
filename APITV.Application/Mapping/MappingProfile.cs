
// using APITV.Domain.Dto.Request.Create;
using APITV.Domain.Dto.QueryFilters;
using APITV.Domain.Dto.Response;
using APITV.Domain.Entities;
using AutoMapper;

namespace APITV.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        // Response

        CreateMap<Platform, PlatformResponseDto>();

        // Create

        // Update

        // Delete

        // QueryFilter

        CreateMap<Platform, PlatformQueryFilter>();
    }
}