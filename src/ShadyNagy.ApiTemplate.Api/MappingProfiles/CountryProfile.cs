using AutoMapper;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Api.MappingProfiles;

public class CountryProfile : Profile
{
  public CountryProfile()
  {
    CreateMap<Country, CountryDto>();
    CreateMap<CountryDto, Country>();
  }
}

