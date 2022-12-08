using GocServer.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Application.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        Task<string> GenerateRefreshToken();
        Task<bool> VerifyToken(Token token);
    }
}
