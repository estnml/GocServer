using GocServer.Domain.Entities;

namespace GocServer.Application.DTOs.Entities.NotificationDto;

public class UpsertNotificationDto
{
    public Guid? Id { get; set; }
    public string Title { get; set; }

    public string Description { get; set; }

    public Guid ModuleId { get; set; }
    public Guid CityId { get; set; }

    public bool IsActive { get; set; }


    public static implicit operator Notification(UpsertNotificationDto notificationDto)
    {
        return new()
        {
            Description = notificationDto.Description,
            IsActive = notificationDto.IsActive,
            CityId = notificationDto.CityId,
            ModuleId = notificationDto.ModuleId,
            Title = notificationDto.Title
        };
    }
}