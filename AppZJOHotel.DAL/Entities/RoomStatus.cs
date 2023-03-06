using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppZJOHotel.DAL.Entities
{
    public class RoomStatus : Entity
    {
        public string Status { get; set; }
        public ICollection<Room> Room { get; set; }
    }
}
