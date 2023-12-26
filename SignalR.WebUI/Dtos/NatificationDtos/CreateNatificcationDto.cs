using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.WebUI.Dtos.NatificationDtos
{
    public class CreateNatificcationDto
    {
        public string? Type { get; set; }
        public string? Icon { get; set; }
        public string? Description { get; set; }

    }
}
