using GocServer.Application.Interfaces.Repositories;
using GocServer.Domain.Entities;
using GocServer.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GocServer.Application.DTOs.Entities.DistrictDto;

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

            var objFromDb = await _context.Districts.FindAsync(id);

            if (objFromDb == null)
            {
                return false;
            }

            objFromDb = districtDto;
            return true;
        }
    }
}