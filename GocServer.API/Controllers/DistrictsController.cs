using GocServer.Application.DTOs.Entities.DistrictDto;
using GocServer.Application.DTOs.Entities.LogDto;
using GocServer.Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GocServer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DistrictsController : ControllerBase
{
    private readonly IDistrictRepository _districtRepository;

    public DistrictsController(IDistrictRepository districtRepository)
    {
        _districtRepository = districtRepository;
    }


    [HttpGet]
    [Route("GetAll")]
    public async Task<ActionResult<IEnumerable<GetDistrictDto>>> GetAll()
    {
        return Ok(await _districtRepository.GetAll().ToListAsync());
    }


    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<ActionResult<GetDistrictDto>> GetById(Guid id)
    {
        return Ok(await _districtRepository.GetByIdAsync(id));
    }


    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (await _districtRepository.RemoveByIdAsync(id))
        {
            await _districtRepository.SaveChangesAsync();
            return Ok();
        }

        return BadRequest();
    }

    [HttpPut]
    [Route("Edit/{id}")]
    public async Task<IActionResult> Edit(Guid id, [FromForm] UpsertDistrictDto districtDto)
    {
        if (await _districtRepository.UpdateAsync(id, districtDto))
        {
            await _districtRepository.SaveChangesAsync();
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromForm] UpsertDistrictDto districtDto)
    {
        if (await _districtRepository.AddAsync(districtDto))
        {
            await _districtRepository.SaveChangesAsync();
            return Ok();
        }

        return BadRequest();
    }
}