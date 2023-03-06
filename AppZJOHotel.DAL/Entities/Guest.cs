
using AppZJOHotel.Common.Ennums;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppZJOHotel.DAL.Entities
{
    public class Guest: Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }       
        public Role Role { get; set; }

        public ICollection<Booking> Booking { get; set; }
    }
}
