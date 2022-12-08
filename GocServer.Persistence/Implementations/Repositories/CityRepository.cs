using GocServer.Application.DTOs.Entities.Edit;
using GocServer.Application.DTOs.Entities.Get;
using GocServer.Application.Interfaces.Repositories;
using GocServer.Domain.Entities;
using GocServer.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Persistence.Implementations.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly AppDbContext _context;

        public CityRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Update(EditCityDto editCityDto)
        {
            var objFromDb = await _context.Cities.FirstOrDefaultAsync(c => c.Id == editCityDto.Id);

            if (objFromDb == null)
            {
                return false;
            }

            objFromDb.IsActive = editCityDto.IsActive;
            objFromDb.Name = editCityDto.Name;

            return true;
        }
    }
}
