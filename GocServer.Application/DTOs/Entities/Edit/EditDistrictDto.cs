﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Application.DTOs.Entities.Edit
{
    public class EditDistrictDto
    {
        public Guid CityId { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
