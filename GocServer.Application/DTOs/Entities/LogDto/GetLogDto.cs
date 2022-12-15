using GocServer.Domain.Entities;

namespace GocServer.Application.DTOs.Entities.LogDto;

public class GetLogDto
{
    
    public Guid DeviceId { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }



    public static implicit operator GetLogDto(Log log)
    {
        return new()
        {
            Description = log.Description,
            Date = log.Date,
            DeviceId = log.DeviceId
        };
    }
}