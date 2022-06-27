namespace ShadyNagy.ApiTemplate.Api.Endpoints.UserEndpoints;

public class ByIdUserRequest
{
  public const string Route = "/users/{id}";
  public static string BuildRoute(int id) => Route.Replace("{id}", id.ToString());
}
