using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Application.DTOs.Entities.Edit
{
    public class EditDeviceDto
    {
        public string Name { get; set; }
        public string Address { get; set; }


        public Guid CityId { get; set; }
        public Guid DistrictId { get; set; }
    }
}
