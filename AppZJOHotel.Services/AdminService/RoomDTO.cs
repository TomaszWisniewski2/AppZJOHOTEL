using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppZJOHotel.Services.AdminService
{
    internal class RoomDTO
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public float RoomPrice { get; set; }
        public int RoomCapacity { get; set; }
        public string? RoomPhoto { get; set; }
        public bool RoomStatus { get; set; }//zajęty nie zajęy
        public string? RoomType { get; set;}
    }
}
