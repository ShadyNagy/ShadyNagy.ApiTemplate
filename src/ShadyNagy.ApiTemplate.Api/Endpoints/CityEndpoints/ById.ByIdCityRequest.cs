namespace ShadyNagy.ApiTemplate.Api.Endpoints.CityEndpoints;

public class ByIdCityRequest
{
  public const string Route = "/cities/{id:int}";
  public static string BuildRoute(int cityId) => Route.Replace("{id:int}", cityId.ToString());
}
