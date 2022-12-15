using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GocServer.Application.DTOs.Entities.ModuleDto;
using GocServer.Application.Interfaces.Utility;
using GocServer.Domain.Entities;

namespace GocServer.Application.Interfaces.Repositories
{
    public interface IModuleRepository : IRepository<Module>, IEditable<UpsertModuleDto>
    {
    }
}