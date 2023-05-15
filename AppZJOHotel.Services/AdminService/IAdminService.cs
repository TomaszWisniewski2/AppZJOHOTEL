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
        Task<string> DeleteRoom(RoomDTO dto);
        Task<RoomTypeDTO> AddRoomType(RoomTypeDTO dto);
        Task<RoomDTO?> EditRoom(RoomDTO dto);
        //Task<GuestDTO?> EditBooking(GuestDTO dto);
        Task<List<RoomDTO?>> ListRooms();
        Task<List<GuestDTO?>> ListGuests();
    }
}
