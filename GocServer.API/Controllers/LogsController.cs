using GocServer.Application.DTOs.Entities.DeviceDto;
using GocServer.Application.DTOs.Entities.LogDto;
using GocServer.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GocServer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LogsController : ControllerBase
{
    private readonly ILogRepository _logRepository;

    public LogsController(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }


    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<IEnumerable<GetLogDto>>> GetAll()
    {
        return Ok(await _logRepository.GetAll().ToListAsync());
    }


    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<ActionResult<GetLogDto>> GetById(Guid id)
    {
        return Ok(await _logRepository.GetByIdAsync(id));
    }


    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (await _logRepository.RemoveByIdAsync(id))
        {
            await _logRepository.SaveChangesAsync();
            return Ok();
        }

        return BadRequest();
    }

    [HttpPut]
    [Route("Edit/{id}")]
    public async Task<IActionResult> Edit(Guid id, [FromForm] UpsertLogDto logDto)
    {
        if (await _logRepository.UpdateAsync(id, logDto))
        {
            await _logRepository.SaveChangesAsync();
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromForm] UpsertLogDto logDto)
    {
        if (await _logRepository.AddAsync(logDto))
        {
            await _logRepository.SaveChangesAsync();
            return Ok();
        }

        return BadRequest();
    }
}