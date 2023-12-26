﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.WebUI.Dtos.FeatureDtos
{
    public class FeatureUpdateDto
    {
        public int FeatureId { get; set; }
        public string? Title1 { get; set; }
        public string? Description1 { get; set; }
        public string? Title2 { get; set; }
        public string? Description2 { get; set; }
        public string? Title3 { get; set; }
        public string? Description3 { get; set; }
    }
}
