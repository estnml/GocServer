using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Application.DTOs.Auth
{
    public class AuthResponse
    {
        public bool Success { get; set; } = false;
        public string? Message { get; set; } = null;
        public Token? Token { get; set; } = null;
    }
}
