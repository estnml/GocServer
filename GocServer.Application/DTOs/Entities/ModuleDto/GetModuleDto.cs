using GocServer.Domain.Entities;

namespace GocServer.Application.DTOs.Entities.ModuleDto;

public class GetModuleDto
{
    public string Name { get; set; }
    public bool IsActive { get; set; }


    public static implicit operator GetModuleDto(Module module)
    {
        return new()
        {
            IsActive = module.IsActive,
            Name = module.Name
        };
    }
}