using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ShadyNagy.ApiTemplate.Core.AppSettings;
using ShadyNagy.ApiTemplate.Core.Entities;
using ShadyNagy.ApiTemplate.Core.Interfaces;

namespace ShadyNagy.ApiTemplate.Infrastructure.Identity;
public class JwtTokenService: IJwtTokenService
{
  private readonly JwtSettings _jwtSettings;

  public JwtTokenService(JwtSettings jwtSettings)
  {
    _jwtSettings = jwtSettings;
  }

  public string GetToken(AuthenticationInfo authenticationInfo)
  {
    var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
    var claims = new List<Claim>
    {
      new(ClaimTypes.Name, authenticationInfo.FullName),
      new(ClaimTypes.Sid, Guid.NewGuid().ToString()),
      new(ClaimTypes.Email, authenticationInfo.Email),
      new(ClaimTypes.PrimarySid, authenticationInfo.Code),
      new(ClaimTypes.NameIdentifier, authenticationInfo.UserName)
    };

    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(claims.ToString()),
      Expires = DateTime.UtcNow.AddDays(1),
      SigningCredentials =
        new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
      Issuer = _jwtSettings.ValidIssuer,
      Audience = _jwtSettings.ValidAudience
    };

    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateToken(tokenDescriptor);

    return tokenHandler.WriteToken(token);
  }
}
