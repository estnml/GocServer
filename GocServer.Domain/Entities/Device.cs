using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Domain.Entities
{
    public class Device
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }


        public Guid CityId { get; set; }
        public Guid DistrictId { get; set; }

        public DateTime LastPing { get; set; }

        public float BatteryLevel { get; set; }

    }
}
