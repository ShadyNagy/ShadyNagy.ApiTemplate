using AutoMapper;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Api.Endpoints.BranchEndpoints;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Api.MappingProfiles;

public class BranchProfile : Profile
{
  public BranchProfile()
  {
    CreateMap<Branch, BranchDto>()
      .ForPath(dest => dest.CityName,
      opt => opt.MapFrom(source => source.City!.Name));
    CreateMap<BranchDto, Branch>();
    CreateMap<AddBranchRequest, Branch>();
    CreateMap<EditBranchRequest, Branch>();
  }
}

