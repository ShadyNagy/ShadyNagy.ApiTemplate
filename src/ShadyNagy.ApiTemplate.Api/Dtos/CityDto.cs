﻿namespace ShadyNagy.ApiTemplate.Api.Dtos;

public class CityDto
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string? CountryId { get; set; }  
}
