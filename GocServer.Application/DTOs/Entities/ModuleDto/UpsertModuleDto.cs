using GocServer.Domain.Entities;

namespace GocServer.Application.DTOs.Entities.ModuleDto;

public class UpsertModuleDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }


    public static implicit operator Module(UpsertModuleDto moduleDto)
    {
        return new()
        {
            IsActive = moduleDto.IsActive,
            Name = moduleDto.Name
        };
    }
}