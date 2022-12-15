using GocServer.Domain.Entities;

namespace GocServer.Application.DTOs.Entities.LogDto;

public class UpsertLogDto
{
    public Guid? Id { get; set; }
    public Guid DeviceId { get; set; }
    
    public DateTime Date { get; set; }
    public string Description { get; set; }


    public static implicit operator Log(UpsertLogDto logDto)
    {
        return new()
        {
            Description = logDto.Description,
            Date = logDto.Date,
            DeviceId = logDto.DeviceId
        };
    }
}