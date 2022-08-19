using System.Linq;
using AutoMapper;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Api.Endpoints.CountryEndpoints;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Core.Specifications;

namespace ShadyNagy.ApiTemplate.Api.MappingProfiles;

public class CountryProfile : Profile
{
  public CountryProfile()
  {
    CreateMap<CountryFilterDto, CountryFilter>();
    CreateMap<Country, CountryDto>()
      .ForPath(dest => dest.Name,
        opt => opt.MapFrom(source => source.CountryTranslations.FirstOrDefault()!.Name));
    CreateMap<CountryDto, Country>();
    CreateMap<AddCountryRequest, Country>();
    CreateMap<EditCountryRequest, Country>();
  }
}

