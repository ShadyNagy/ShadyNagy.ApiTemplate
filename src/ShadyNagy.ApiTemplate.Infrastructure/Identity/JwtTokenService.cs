﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ShadyNagy.ApiTemplate.Core.AppSettings;
using ShadyNagy.ApiTemplate.Core.Entities;

namespace ShadyNagy.ApiTemplate.Infrastructure.Identity;
public class JwtTokenService
{
  private readonly JwtSettings _jwtSettings;

  public JwtTokenService(JwtSettings jwtSettings)
  {
    _jwtSettings = jwtSettings;
  }

  public string GetTokenAsync(AuthenticationInfo authenticationInfo)
  {
    var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
    var claims = new List<Claim>
    {
      new Claim(ClaimTypes.Name, authenticationInfo.FullName),
      new Claim(ClaimTypes.Sid, Guid.NewGuid().ToString()),
      new Claim(ClaimTypes.Email, authenticationInfo.Email),
      new Claim(ClaimTypes.PrimarySid, authenticationInfo.Code),
      new Claim(ClaimTypes.NameIdentifier, authenticationInfo.UserName)
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
