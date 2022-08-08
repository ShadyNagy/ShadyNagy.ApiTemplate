using System.Collections.Generic;
using System.Threading.Tasks;
using ShadyNagy.ApiTemplate.Api.Dtos;

namespace ShadyNagy.ApiTemplate.Api.Interfaces;

public interface ICountryUiService
{
  Task<List<CountryDto>> GetCountriesByFilterAsync(CountryFilterDto filter);
}
