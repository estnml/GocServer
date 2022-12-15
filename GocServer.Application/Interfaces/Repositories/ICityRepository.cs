using GocServer.Application.DTOs.Entities.CityDto;
using GocServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GocServer.Application.Interfaces.Utility;

namespace GocServer.Application.Interfaces.Repositories
{
    public interface ICityRepository : IRepository<City>, IEditable<UpsertCityDto>
    {
    }
}