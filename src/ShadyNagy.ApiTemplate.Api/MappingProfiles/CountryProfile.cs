using AutoMapper;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Api.Endpoints.CountryEndpoints;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Core.Specifications.Filters;

namespace ShadyNagy.ApiTemplate.Api.MappingProfiles;

public class CountryProfile : Profile
{
  public CountryProfile()
  {
    CreateMap<CountryFilterDto, CountryFilter>();
    CreateMap<Country, CountryDto>();
    CreateMap<CountryDto, Country>();
    CreateMap<AddCountryRequest, Country>();
    CreateMap<EditCountryRequest, Country>();
  }
}

