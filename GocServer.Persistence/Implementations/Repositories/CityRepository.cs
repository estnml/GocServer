using GocServer.Application.DTOs.Entities.CityDto;
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


        public async Task<bool> UpdateAsync(Guid id, UpsertCityDto cityDto)
        {
            if (id != cityDto.Id)
            {
                return false;
            }

            var objFromDb = await _context.Cities.FindAsync(id);

            if (objFromDb == null)
            {
                return false;
            }

            objFromDb = cityDto;
            return true;
        }
    }
}