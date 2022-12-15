using AutoMapper;
using GocServer.Application.DTOs.Entities.CityDto;
using GocServer.Application.Interfaces.Repositories;
using GocServer.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GocServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CitiesController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<GetCityDto>>> GetAll()
        {
            return Ok(await _cityRepository.GetAll().ToListAsync());
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<GetCityDto>> GetById(Guid id)
        {
            return Ok(await _cityRepository.GetByIdAsync(id));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _cityRepository.RemoveByIdAsync(id))
            {
                await _cityRepository.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<ActionResult<bool>> Edit(Guid id, [FromBody] UpsertCityDto cityDto)
        {
            if (await _cityRepository.UpdateAsync(id, cityDto))
            {
                await _cityRepository.SaveChangesAsync();
                return Ok();
            }


            return BadRequest();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] UpsertCityDto cityDto)
        {
            if (await _cityRepository.AddAsync(cityDto))
            {
                await _cityRepository.SaveChangesAsync();
                return Ok();
            }

            return BadRequest();
        }
    }
}