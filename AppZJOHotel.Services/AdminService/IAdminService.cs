using AppZJOHotel.Services.GuestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppZJOHotel.Services.AdminService
{
    internal interface IAdminService
    {
        Task<GuestDTO> AddRoom(GuestDTO guest);
        Task<GuestDTO?> DeleteRoom(GuestDTO dto);
        Task<GuestDTO> EditRoom(GuestDTO guest);
        Task<GuestDTO?> EditBooking(GuestDTO dto);
        Task<GuestDTO> GetRoomList(GuestDTO guest);
        Task<GuestDTO?> GetGuestList(GuestDTO dto);
    }
}
