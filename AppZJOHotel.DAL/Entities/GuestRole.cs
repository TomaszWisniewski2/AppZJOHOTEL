using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppZJOHotel.DAL.Entities
{
    public class GuestRole: Entity
    {
        public string Role { get; set; }

        public ICollection<Guest> Guest { get; set; }
    }
}
