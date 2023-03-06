using AppZJOHotel.Common.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppZJOHotel.DAL.Entities
{
    public class Booking : Entity
    {
        public DateTime BookingFrom { get; set; }
        public DateTime BookingTo { get; set; }
        public double ToPay { get; set; }//Do zapłaty
        public PaymentType PaymentType { get; set; }

        [ForeignKey(nameof(Guest))]
        public int GuestId { get; set; }
        public virtual Guest? Guest { get; set; }

        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }
        public Room? Room { get; set; }

        //[ForeignKey(nameof(PaymentType))]
        //public int PaymentTypeId { get; set; }
        //public PaymentType PaymentType { get; set; }
    }
}
