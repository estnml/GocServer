using GocServer.Application.DTOs.Entities.ModuleDto;
using GocServer.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GocServer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModulesController : ControllerBase
{
    private readonly IModuleRepository _moduleRepository;


    public ModulesController(IModuleRepository moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }


    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<IEnumerable<GetModuleDto>>> GetAll()
    {
        return Ok(await _moduleRepository.GetAll().ToListAsync());
    }


    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<ActionResult<GetModuleDto>> GetById(Guid id)
    {
        return Ok(await _moduleRepository.GetByIdAsync(id));
    }


    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (await _moduleRepository.RemoveByIdAsync(id))
        {
            await _moduleRepository.SaveChangesAsync();
            return Ok();
        }

        return BadRequest();
    }

    [HttpPut]
    [Route("Edit/{id}")]
    public async Task<IActionResult> Edit(Guid id, [FromForm] UpsertModuleDto moduleDto)
    {
        if (await _moduleRepository.UpdateAsync(id, moduleDto))
        {
            await _moduleRepository.SaveChangesAsync();
            return Ok();
        }


        return BadRequest();
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromForm] UpsertModuleDto moduleDto)
    {
        if (await _moduleRepository.AddAsync(moduleDto))
        {
            await _moduleRepository.SaveChangesAsync();
            return Ok();
        }

        return BadRequest();
    }
}