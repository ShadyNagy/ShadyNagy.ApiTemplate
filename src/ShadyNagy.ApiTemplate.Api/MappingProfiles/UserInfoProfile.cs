using AutoMapper;
using ShadyNagy.ApiTemplate.Api.Dtos;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Api.MappingProfiles;

public class UserInfoProfile : Profile
{
  public UserInfoProfile()
  {
    CreateMap<UserInfo, UserInfoDto>();
    CreateMap<UserInfoDto, UserInfo>();
  }
}

