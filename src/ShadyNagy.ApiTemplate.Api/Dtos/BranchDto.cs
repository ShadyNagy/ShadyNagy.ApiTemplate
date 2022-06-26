using System.ComponentModel.DataAnnotations;

namespace ShadyNagy.ApiTemplate.Api.Dtos;
public class BranchDto
{
  public int Id { get; set; }
  [Required]
  public string Name { get; set; } = string.Empty;
  [Required]
  public string Address { get; set; } = string.Empty;
  public string? Phone { get; set; }
  public string? Email { get; set; }
  public string? CityName { get; set; }
  public int CityId { get; set; }
}
