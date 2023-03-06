
using System.ComponentModel.DataAnnotations.Schema;

namespace AppZJOHotel.DAL.Entities
{
    public class Guest: Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [ForeignKey(nameof(GuestRole))]
        public int GuestRoleId { get; set; }
        public GuestRole GuestRole { get; set; }

        public ICollection<Booking> Booking { get; set; }
    }
}
