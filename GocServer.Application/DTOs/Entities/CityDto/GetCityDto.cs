using GocServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Application.DTOs.Entities.CityDto
{
    public class GetCityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }


        public static implicit operator GetCityDto(City city)
        {
            return new()
            {
                Name = city.Name,
                IsActive = city.IsActive,
                Id = city.Id
            };
        }
    }
}