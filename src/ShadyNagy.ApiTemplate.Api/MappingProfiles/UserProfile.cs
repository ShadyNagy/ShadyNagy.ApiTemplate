using AutoMapper;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Api.MappingProfiles;

public class UserProfile : Profile
{
  public UserProfile()
  {
    CreateMap<User, UserDto>();
    CreateMap<UserDto, User>();
  }
}

