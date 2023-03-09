using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppZJOHotel.Services.GuestService
{
    public interface IGuestService
    {
        Task<List<GuestDTO?>> ListGuests();
    }
}
