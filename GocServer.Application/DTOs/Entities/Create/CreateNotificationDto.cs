using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Application.DTOs.Entities.Create
{
    public class CreateNotificationDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Guid ModuleId { get; set; }
        public Guid CityId { get; set; }

        public bool IsActive { get; set; }
    }
}
