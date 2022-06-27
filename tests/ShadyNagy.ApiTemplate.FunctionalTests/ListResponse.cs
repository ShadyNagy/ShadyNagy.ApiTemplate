using System.Collections.Generic;

namespace ShadyNagy.ApiTemplate.FunctionalTests;

public class ListResponse<T>
{
  public List<T> Data { get; set; } = new();
  public int TotalCount { get; set; } = 0;
  public int PageNumber { get; set; } = 0;
}
