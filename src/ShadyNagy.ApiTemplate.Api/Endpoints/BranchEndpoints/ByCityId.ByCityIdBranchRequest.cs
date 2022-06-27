using System.ComponentModel.DataAnnotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.BranchEndpoints;

public class ByCityIdBranchRequest
{
  public const string Route = "/branches/by-city-id/{cityId:int}";
  public static string BuildRoute(int cityId) => Route.Replace("{cityId:int}", cityId.ToString());
}
