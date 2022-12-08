using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Application.DTOs.Entities.Get
{
    public class GetCityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
