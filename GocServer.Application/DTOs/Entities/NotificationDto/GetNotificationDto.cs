using GocServer.Domain.Entities;

namespace GocServer.Application.DTOs.Entities.NotificationDto;

public class GetNotificationDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public string Description { get; set; }

    public Guid ModuleId { get; set; }
    public Guid CityId { get; set; }

    public bool IsActive { get; set; }


    public static implicit operator GetNotificationDto(Notification notification)
    {
        return new()
        {
            Description = notification.Description,
            CityId = notification.CityId,
            IsActive = notification.IsActive,
            ModuleId = notification.ModuleId,
            Title = notification.Title,
            Id = notification.Id
        };
    }
}