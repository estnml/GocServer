using AutoMapper;
using GocServer.Application.DTOs.Entities.Create;
using GocServer.Application.DTOs.Entities.Get;
using GocServer.Domain.Entities;
using GocServer.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Application
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            // Create
            CreateMap<CreateCityDto, City>();



            // GET
            CreateMap<City, GetCityDto>();
            CreateMap<Device, GetDeviceDto>();
            CreateMap<Notification, GetNotificationDto>();
            CreateMap<User, GetUserDto>();
            CreateMap<Module, GetModuleDto>();
            CreateMap<District, GetDistrictDto>();
            CreateMap<Log, GetLogDto>();
        }
    }
}
