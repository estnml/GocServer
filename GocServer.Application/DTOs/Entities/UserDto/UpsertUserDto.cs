namespace GocServer.Application.DTOs.Entities.UserDto;

public class UpsertUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}