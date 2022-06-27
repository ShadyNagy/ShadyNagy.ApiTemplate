using System.ComponentModel.DataAnnotations;

namespace ShadyNagy.ApiTemplate.Api.Endpoints.BranchEndpoints;

public class AddBranchRequest
{
  public const string Route = "/branches";

  [Required]
  public string Name { get; set; } = string.Empty;
  [Required]
  public string Address { get; set; } = string.Empty;
  public string? Phone { get; set; }
  public string? Email { get; set; }
  public string? CityName { get; set; }
  public int CityId { get; set; }
}
