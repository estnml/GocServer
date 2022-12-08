using GocServer.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Application.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(LoginRequestDto loginRequestDto);
        Task<AuthResponse> Register(RegisterRequestDto registerRequestDto);
    }
}
