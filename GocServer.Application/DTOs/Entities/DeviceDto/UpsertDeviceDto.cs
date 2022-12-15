using GocServer.Application.DTOs.Entities.NotificationDto;
using GocServer.Domain.Entities;

namespace GocServer.Application.DTOs.Entities.DeviceDto;

public class UpsertDeviceDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }


    public Guid CityId { get; set; }
    public Guid DistrictId { get; set; }

    public DateTime LastPing { get; set; }

    public float BatteryLevel { get; set; }



    public static implicit operator Device(UpsertDeviceDto deviceDto)
    {
        return new()
        {
            Name = deviceDto.Name,
            DistrictId = deviceDto.DistrictId,
            CityId = deviceDto.CityId,
            Address = deviceDto.Address,
            LastPing = deviceDto.LastPing,
            BatteryLevel = deviceDto.BatteryLevel
        };
    }
}