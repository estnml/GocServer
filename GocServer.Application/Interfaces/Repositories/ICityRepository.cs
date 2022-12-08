using GocServer.Application.DTOs.Entities.Edit;
using GocServer.Application.DTOs.Entities.Get;
using GocServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Application.Interfaces.Repositories
{
    public interface ICityRepository : IRepository<City>
    {
        Task<bool> Update(EditCityDto editCityDto);
    }
}
