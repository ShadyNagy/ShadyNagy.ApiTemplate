using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Api.Interfaces;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Core.Specifications;
using ShadyNagy.ApiTemplate.SharedKernel.Interfaces;

namespace ShadyNagy.ApiTemplate.Api.Services;

public class CountryUiService : ICountryUiService
{
  private readonly IMapper _mapper;
  private readonly IReadRepository<Country> _countryRepository;

  public CountryUiService(IMapper mapper, IReadRepository<Country> countryRepository) {
    _mapper = mapper;
    _countryRepository = countryRepository;
  }

  public async Task<List<CountryDto>> GetCountriesByFilterAsync(CountryFilterDto countryFilter)
  {
    var filter = _mapper.Map<CountryFilter>(countryFilter);
    var spec = new CountriesByFilterSpec(filter);

    var countries = await _countryRepository.ListAsync(spec);

    return _mapper.Map<List<CountryDto>>(countries);
  }
}
