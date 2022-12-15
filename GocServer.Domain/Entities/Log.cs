using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Domain.Entities
{
    public class Log
    {
        public Guid Id { get; set; }
        public Guid DeviceId { get; set; }


        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
