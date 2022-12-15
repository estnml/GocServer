using GocServer.Domain.Entities;

namespace GocServer.Application.DTOs.Entities.DistrictDto;

public class GetDistrictDto
{
    
    public Guid CityId { get; set; }
    public string Name { get; set; }

    public bool IsActive { get; set; }


    public static implicit operator GetDistrictDto(District district)
    {
        return new()
        {
            IsActive = district.IsActive,
            Name = district.Name,
            CityId = district.CityId
        };
    }
}