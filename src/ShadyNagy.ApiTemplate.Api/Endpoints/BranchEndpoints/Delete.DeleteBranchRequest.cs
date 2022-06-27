using System.ComponentModel.DataAnnotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.BranchEndpoints;

public class DeleteBranchRequest
{
  public const string Route = "/branches/{id:int}";
  public static string BuildRoute(int branchId) => Route.Replace("{id:int}", branchId.ToString());
}
