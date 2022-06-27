namespace ShadyNagy.ApiTemplate.Api.Endpoints.UserEndpoints;

public class DeleteUserRequest
{
  public const string Route = "/users/{id}";
  public static string BuildRoute(int cityId) => Route.Replace("{id}", cityId.ToString());
}
