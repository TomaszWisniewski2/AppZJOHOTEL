using AppZJOHotel.Services.GuestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppZJOHotel.Services.AdminService
{
    public interface IAdminService
    {
        Task<RoomDTO> AddRoom(RoomDTO dto);
        //Task<GuestDTO?> DeleteRoom(GuestDTO dto);
        Task<RoomTypeDTO> AddRoomType(RoomTypeDTO dto);
        //Task<GuestDTO> EditRoom(GuestDTO guest);
        //Task<GuestDTO?> EditBooking(GuestDTO dto);
        //Task<GuestDTO> GetRoomList(GuestDTO guest);
        //Task<GuestDTO?> GetGuestList(GuestDTO dto);
    }
}
