using GocServer.Application.DTOs.Auth;
using GocServer.Application.Interfaces.Services;
using GocServer.Application.Services;
using GocServer.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Persistence.Implementations.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;

        public AuthService(IJwtService jwtService, UserManager<User> userManager)
        {
            _jwtService = jwtService;
            _userManager = userManager;
        }


        public async Task<AuthResponse> Login(LoginRequestDto loginRequestDto)
        {
            var authResponse = new AuthResponse();
            var user = await _userManager.FindByNameAsync(loginRequestDto.Username);

            if (user == null)
            {
                return authResponse;
            }


            var validPassword = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (!validPassword)
            {
                authResponse.Message = "Invalid password or username";
                return authResponse;
            }

            
            var userClaims = await GenerateUserClaimsAsync(user);

            authResponse.Success = true;
            authResponse.Message = "Login successful";
            authResponse.Token = new Token()
            {
                AccessToken = _jwtService.GenerateAccessToken(userClaims),
                RefreshToken = await _jwtService.GenerateRefreshToken()
            };

            return authResponse;
        }

        public async Task<AuthResponse> Register(RegisterRequestDto registerRequestDto)
        {
            var authResponse = new AuthResponse();
            var user = await _userManager.FindByNameAsync(registerRequestDto.Username);

            if (user != null)
            {
                authResponse.Message = "Username has taken.";
                return authResponse;
            }


            var result = await _userManager.CreateAsync(user, registerRequestDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                
                var userClaims = await GenerateUserClaimsAsync(user);

                authResponse.Success = true;
                authResponse.Token = new Token()
                {
                    AccessToken = _jwtService.GenerateAccessToken(userClaims),
                    RefreshToken = await _jwtService.GenerateRefreshToken()
                };
                authResponse.Message = "User created successfully.";
            }

            return authResponse;
        }

        private async Task<IEnumerable<Claim>> GenerateUserClaimsAsync(User user)
        {

            var userClaims = await _userManager.GetClaimsAsync(user);

            var userRoles = await _userManager.GetRolesAsync(user);
            var roleClaims = userRoles.Select(x => new Claim(ClaimTypes.Role, x));


            return userClaims.Union(roleClaims);

        }
    }
}
