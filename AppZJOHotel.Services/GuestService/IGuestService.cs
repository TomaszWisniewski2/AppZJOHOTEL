using AppZJOHotel.Services.AdminService;
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
        Task<List<RoomDTO?>> ListRooms();
        Task<BookingDTO> BookinkRoom(BookingDTO dto);
        Task<EditBookingDTO> EditBookink(EditBookingDTO dto);
        Task<string> DeleteBooking(int id);
        Task<BookingDTO?> GetBooking(int id);//informacje o rezerwacji
        Task<String> Payment(int enu, int id);



    }
}
