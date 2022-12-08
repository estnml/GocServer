using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Application.DTOs.Entities.Edit
{
    public class EditLogDto
    {
        public Guid DeviceId { get; set; }


        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
