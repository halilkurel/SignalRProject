﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.WebUI.Dtos.SocialMediaDto
{
    public class SocialMediaCreateDto
    {
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
    }
}