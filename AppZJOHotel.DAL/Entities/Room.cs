using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppZJOHotel.DAL.Entities
{
    public class Room : Entity
    {
        public int RoomNumber { get; set; }
        public double RoomPrice { get; set; }
        public int RoomCapacity { get; set; }
        public string RoomPhoto { get; set; }

        [ForeignKey(nameof(RoomType))]
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }

        [ForeignKey(nameof(RoomStatus))]
        public int RoomStatusId { get; set; }
        public RoomStatus RoomStatus { get; set; }

        public ICollection<Booking> Booking { get; set; }
    }
}
