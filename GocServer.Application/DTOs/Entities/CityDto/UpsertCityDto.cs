using GocServer.Domain.Entities;

namespace GocServer.Application.DTOs.Entities.CityDto;

public class UpsertCityDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; } = false;

    public static implicit operator City(UpsertCityDto cityDto)
    {
        return new()
        {
            Name = cityDto.Name,
            IsActive = cityDto.IsActive
        };
    }
}