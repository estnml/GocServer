using GocServer.Application.DTOs.Entities.CityDto;
using GocServer.Application.DTOs.Entities.DeviceDto;
using GocServer.Application.DTOs.Entities.NotificationDto;
using GocServer.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GocServer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationsController : ControllerBase
{
    private readonly INotificationRepository _notificationRepository;


    public NotificationsController(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }


    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<IEnumerable<GetNotificationDto>>> GetAll()
    {
        return Ok(await _notificationRepository.GetAll().ToListAsync());
    }


    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<ActionResult<GetNotificationDto>> GetById(Guid id)
    {
        return Ok(await _notificationRepository.GetByIdAsync(id));
    }


    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (await _notificationRepository.RemoveByIdAsync(id))
        {
            await _notificationRepository.SaveChangesAsync();
            return Ok();
        }

        return BadRequest();
    }

    [HttpPut]
    [Route("Edit/{id}")]
    public async Task<IActionResult> Edit(Guid id, [FromForm] UpsertNotificationDto notificationDto)
    {
        if (await _notificationRepository.UpdateAsync(id, notificationDto))
        {
            await _notificationRepository.SaveChangesAsync();
            return Ok();
        }


        return BadRequest();
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromForm] UpsertNotificationDto notificationDto)
    {
        if (await _notificationRepository.AddAsync(notificationDto))
        {
            await _notificationRepository.SaveChangesAsync();
            return Ok();
        }

        return BadRequest();
    }
}