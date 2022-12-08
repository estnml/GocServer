using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Persistence
{
    public static class Constants
    {
        private readonly static ConfigurationManager _configuration;

        static Constants()
        {
            _configuration = new ConfigurationManager();
            _configuration
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../GocServer.API"))
                .AddJsonFile("appsettings.json");

        }

        public static string ConnectionString => _configuration.GetConnectionString("Postgres");

        public static string ValidIssuer => _configuration["Jwt:Issuer"];
        public static string ValidAudience => _configuration["Jwt:Audience"];
        public static string JwtSecurityKey => _configuration["Jwt:SecurityKey"];
        
    }
}
