using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Application.DTOs.Entities.Create
{
    public class CreateLogDto
    {
        public Guid DeviceId { get; set; }


        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
