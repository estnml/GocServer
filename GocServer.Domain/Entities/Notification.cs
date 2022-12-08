using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Domain.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public Guid ModuleId { get; set; }
        public Guid CityId { get; set; }

        public bool IsActive { get; set; }
    }
}
