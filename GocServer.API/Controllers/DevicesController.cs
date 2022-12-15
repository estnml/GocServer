using GocServer.Application.DTOs.Entities.DeviceDto;
using GocServer.Application.Interfaces.Repositories;
using GocServer.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GocServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceRepository _deviceRepository;

        public DevicesController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }


        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<GetDeviceDto>>> GetAll()
        {
            return Ok(await _deviceRepository.GetAll().ToListAsync());
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<GetDeviceDto>> GetById(Guid id)
        {
            return Ok(await _deviceRepository.GetByIdAsync(id));
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _deviceRepository.RemoveByIdAsync(id))
            {
                await _deviceRepository.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromForm] UpsertDeviceDto deviceDto)
        {
            if (await _deviceRepository.UpdateAsync(id, deviceDto))
            {
                await _deviceRepository.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromForm] UpsertDeviceDto deviceDto)
        {
            if (await _deviceRepository.AddAsync(deviceDto))
            {
                await _deviceRepository.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }
    }
}