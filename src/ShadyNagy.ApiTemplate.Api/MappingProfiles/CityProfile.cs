using System.Linq;
using AutoMapper;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Api.Endpoints.CityEndpoints;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Api.MappingProfiles;

public class CityProfile : Profile
{
  public CityProfile()
  {
    CreateMap<City, CityDto>()
      .ForPath(dest => dest.Name,
        opt => opt.MapFrom(source => source.CityTranslations.FirstOrDefault()!.Name));
    CreateMap<CityDto, City>();
    CreateMap<AddCityRequest, City>();
    CreateMap<EditCityRequest, City>();
  }
}

