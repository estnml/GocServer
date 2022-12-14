using GocServer.Application.Interfaces.Repositories;
using GocServer.Domain.Entities;
using GocServer.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GocServer.Application.DTOs.Entities.ModuleDto;
using Microsoft.EntityFrameworkCore;

namespace GocServer.Persistence.Implementations.Repositories
{
    public class ModuleRepository : Repository<Module>, IModuleRepository
    {
        private readonly AppDbContext _context;

        public ModuleRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> UpdateAsync(Guid id, UpsertModuleDto moduleDto)
        {
            if (id != moduleDto.Id)
            {
                return false;
            }
            
            var objFromDb = await _context.Modules.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
  

            if (objFromDb == null)
            {
                return false;
            }

            objFromDb = moduleDto;
            _context.Entry(objFromDb).State = EntityState.Modified;

            return true;
        }
    }
}
