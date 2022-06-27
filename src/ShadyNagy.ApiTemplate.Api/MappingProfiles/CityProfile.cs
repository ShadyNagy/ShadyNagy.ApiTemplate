using AutoMapper;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Api.Endpoints.CityEndpoints;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Api.MappingProfiles;

public class CityProfile : Profile
{
  public CityProfile()
  {
    CreateMap<City, CityDto>();
    CreateMap<CityDto, City>();
    CreateMap<AddCityRequest, City>();
    CreateMap<EditCityRequest, City>();
  }
}

