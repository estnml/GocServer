using GocServer.Application.Interfaces.Repositories;
using GocServer.Domain.Entities;
using GocServer.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GocServer.Application.DTOs.Entities.LogDto;

namespace GocServer.Persistence.Implementations.Repositories
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        private readonly AppDbContext _context;

        public LogRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> UpdateAsync(Guid id, UpsertLogDto logDto)
        {
            if (id != logDto.Id)
            {
                return false;
            }
            
            var objFromDb = await _context.Logs.FindAsync(id);

            if (objFromDb == null)
            {
                return false;
            }

            objFromDb = logDto;
            return true;

        }
    }
}
