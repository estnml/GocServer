using AutoMapper;
using GocServer.Application.DTOs.Entities.Create;
using GocServer.Application.DTOs.Entities.Edit;
using GocServer.Application.DTOs.Entities.Get;
using GocServer.Application.Interfaces.Repositories;
using GocServer.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GocServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<GetCityDto> GetAll()
        {
            return _mapper.Map<List<GetCityDto>>(_cityRepository.GetAll());
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<GetCityDto>> GetById(Guid id)
        {
            return _mapper.Map<GetCityDto>(await _cityRepository.GetByIdAsync(id));
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (await _cityRepository.RemoveByIdAsync(id))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<ActionResult<bool>> Edit(Guid id, EditCityDto editCityDto)
        {
            if (id != editCityDto.Id)
            {
                return BadRequest();
            }

            if(await _cityRepository.Update(editCityDto))
            {
                await _cityRepository.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCityDto createCityDto)
        {
            var record = _mapper.Map<City>(createCityDto);
            await _cityRepository.AddAsync(record);
            await _cityRepository.SaveChangesAsync();

            return Ok();
        }
    }
}
