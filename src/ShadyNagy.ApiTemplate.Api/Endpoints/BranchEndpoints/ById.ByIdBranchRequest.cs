using System.ComponentModel.DataAnnotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.BranchEndpoints;

public class ByIdBranchRequest
{
  public const string Route = "/branches/{id:int}";
  public static string BuildRoute(int id) => Route.Replace("{id:int}", id.ToString());
}
