using GocServer.Application.Interfaces.Repositories;
using GocServer.Domain.Entities;
using GocServer.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GocServer.Application.DTOs.Entities.DistrictDto;
using Microsoft.EntityFrameworkCore;

namespace GocServer.Persistence.Implementations.Repositories
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        private readonly AppDbContext _context;

        public DistrictRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> UpdateAsync(Guid id, UpsertDistrictDto districtDto)
        {
            if (id != districtDto.Id)
            {
                return false;
            }

            var objFromDb = await _context.Districts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (objFromDb == null)
            {
                return false;
            }

            objFromDb = districtDto;
            _context.Entry(objFromDb).State = EntityState.Modified;

            return true;
        }
    }
}