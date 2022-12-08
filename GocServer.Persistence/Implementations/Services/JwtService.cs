using GocServer.Application.DTOs.Auth;
using GocServer.Application.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Persistence.Implementations.Services
{
    public class JwtService : IJwtService
    {
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.JwtSecurityKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                issuer: Constants.ValidIssuer,
                audience: Constants.ValidAudience,
                signingCredentials: credentials,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15)
            );


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public Task<string> GenerateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyToken(Token token)
        {
            throw new NotImplementedException();
        }
    }
}
