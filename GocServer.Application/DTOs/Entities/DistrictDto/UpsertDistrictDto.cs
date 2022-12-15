using GocServer.Domain.Entities;

namespace GocServer.Application.DTOs.Entities.DistrictDto;

public class UpsertDistrictDto
{
    public Guid? Id { get; set; }
    public Guid CityId { get; set; }
    public string Name { get; set; }

    public bool IsActive { get; set; }


    public static implicit operator District(UpsertDistrictDto districtDto)
    {
        return new()
        {
            IsActive = districtDto.IsActive,
            Name = districtDto.Name,
            CityId = districtDto.CityId
        };
    }
}