﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.NatificationDto
{
    public class CreateNatificcationDto
    {
        public string? Type { get; set; }
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public bool? Status { get; set; }
    }
}
