﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.WebUI.Dtos.BookingDto
{
    public class BookingUpdateDto
    {
        public int BookingId { get; set; }
        public string? Name { get; set; }
		public string? Description { get; set; }
		public string? Phone { get; set; }
        public string? Mail { get; set; }
        public string? PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}
