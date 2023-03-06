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
        public float RoomPrice { get; set; }
        public int RoomCapacity { get; set; }
        public string? RoomPhoto { get; set; }
        public bool RoomStatus { get; set; }//zajęty nie zajęy

        [ForeignKey(nameof(RoomType))]
        public int RoomTypeId { get; set; }
        public RoomType? RoomType { get; set; }

        public ICollection<Booking>? Booking { get; set; }
    }
}
