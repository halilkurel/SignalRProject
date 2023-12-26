using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.WebUI.Dtos.AboutDto
{
    public class AboutUpdateDto
    {
        public int AboutId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Descripetion { get; set; }
        public string? Title { get; set; }
    }
}
