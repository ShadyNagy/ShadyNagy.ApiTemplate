using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Core.Interfaces;
public interface IJwtTokenService
{
  string GetToken(AuthenticationInfo authenticationInfo);
}
