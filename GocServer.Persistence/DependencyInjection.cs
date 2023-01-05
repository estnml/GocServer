using GocServer.Application.Interfaces.Repositories;
using GocServer.Application.Interfaces.Services;
using GocServer.Application.Services;
using GocServer.Domain.Entities.Identity;
using GocServer.Persistence.Contexts;
using GocServer.Persistence.Implementations.Repositories;
using GocServer.Persistence.Implementations.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Persistence
{
    public static class DependencyInjection
    {
        public static void RegisterPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(Constants.ConnectionString));

            services
                .AddIdentityCore<User>().AddUserManager<UserManager<User>>()
                .AddRoles<Role>().AddRoleManager<RoleManager<Role>>()
                .AddEntityFrameworkStores<AppDbContext>();


            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();
        }
    }
}
