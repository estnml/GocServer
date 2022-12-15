namespace GocServer.Application.Interfaces.Utility;

public interface IEditable<EditTDto> where EditTDto : class
{
    Task<bool> UpdateAsync(Guid id, EditTDto editDto);
}