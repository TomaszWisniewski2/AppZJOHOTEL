using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppZJOHotel.Services.GuestService
{
    public interface IGuestService
    {
        Task<List<GuestDTO?>> ListGuests();//do admina
        Task<GuestDTO> RegisterGuest(GuestDTO guest);
        Task<GuestDTO?> EditGuest(GuestDTO dto);
        Task<int> Login(LoginDTO dto);
        //Task<GuestDTO> Bookink(GuestDTO guest);
        //Task<GuestDTO> EditBookink(GuestDTO guest);
        //Task<GuestDTO> BookinkInfo(GuestDTO guest);//informacje o rezerwacji
        //Task<GuestDTO> Payment(GuestDTO guest);



    }
}
