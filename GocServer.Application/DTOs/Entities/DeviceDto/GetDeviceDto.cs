using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GocServer.Domain.Entities;

namespace GocServer.Application.DTOs.Entities.DeviceDto
{
    public class GetDeviceDto
    {
        
        public string Name { get; set; }
        public string Address { get; set; }


        public Guid CityId { get; set; }
        public Guid DistrictId { get; set; }

        public DateTime LastPing { get; set; }

        public float BatteryLevel { get; set; }


        public static implicit operator GetDeviceDto(Device device)
        {
            return new()
            {
                Name = device.Name,
                DistrictId = device.DistrictId,
                CityId = device.CityId,
                Address = device.Address,
                LastPing = device.LastPing,
                BatteryLevel = device.BatteryLevel,
                
            };
        }
    }
}
