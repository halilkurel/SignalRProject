﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.WebUI.Dtos.SocialMediaDto
{
    public class SocialMediaListDto
    {
        public int SocialMediaId { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Icon { get; set; }
    }
}
