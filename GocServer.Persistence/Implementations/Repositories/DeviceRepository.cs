using GocServer.Application.Interfaces.Repositories;
using GocServer.Domain.Entities;
using GocServer.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GocServer.Application.DTOs.Entities.DeviceDto;
using Microsoft.EntityFrameworkCore;

namespace GocServer.Persistence.Implementations.Repositories
{
    public class DeviceRepository : Repository<Device>, IDeviceRepository
    {
        private readonly AppDbContext _context;

        public DeviceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> UpdateAsync(Guid id, UpsertDeviceDto deviceDto)
        {
            if (id != deviceDto.Id)
            {
                return false;
            }
            
            var objFromDb = await _context.Devices.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);

            if (objFromDb == null)
            {
                return false;
            }

            objFromDb = deviceDto;
            _context.Entry(objFromDb).State = EntityState.Modified;

            return true;
        }
    }
}