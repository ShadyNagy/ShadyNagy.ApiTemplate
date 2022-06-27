namespace ShadyNagy.ApiTemplate.Api.Endpoints.CountryEndpoints;

public class ByIdCountryRequest
{
  public const string Route = "/countries/{id}";
  public static string BuildRoute(int cityId) => Route.Replace("{id}", cityId.ToString());
}
