using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppZJOHotel.Services.GuestService
{
    public class BookingDTO
    {
        public int? GuestId { get; set; }
        public int? RoomId { get; set; }
        public int RoomNr { get; set; }
        public DateTime? BookingFrom { get; set; }
        public DateTime? BookingTo { get; set; }


    }
}
