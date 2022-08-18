namespace ShadyNagy.ApiTemplate.Api.Dtos;

public class BaseFilterDto
{
  public int Page { get; set; } = 1;
  public int PageSize { get; set; } = 10;
}
