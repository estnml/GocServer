using GocServer.Application.DTOs.Entities.Create;
using GocServer.Application.DTOs.Entities.Get;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GocServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<GetCityDto>>> GetAll()
        {
            return Ok();
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<GetCityDto>> GetById(Guid id)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok();
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromForm] CreateDistrictDto createDistrictDto)
        {
            return Ok();
        }
    }
}
