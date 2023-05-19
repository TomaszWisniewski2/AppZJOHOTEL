using AppZJOHotel.Services.AdminService;
using AppZJOHotel.Services.GuestService;
using Microsoft.AspNetCore.Mvc;
using AppZJOHotel.DAL.Entities;
using AppZJOHotel.Types;
namespace AppZJOHotel.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }
        [HttpPost("AddRoomType")]
        public Task<RoomTypeDTO> AddRoomType([FromBody] RoomTypeDTO dto) => adminService.AddRoomType(dto);
        [HttpPost("AddRoom")]
        public Task<RoomDTO> AddRoom([FromBody] RoomDTO dto) => adminService.AddRoom(dto);
        [HttpPut("EditRoom")]
        public Task<RoomDTO?> EditRoom([FromBody] RoomDTO dto) => adminService.EditRoom(dto);
        [HttpPost("DeleteRoom")]
        public Task<string> DeleteRoom([FromBody] RoomDTO dto)=> adminService.DeleteRoom(dto);
        [HttpGet("ListRoom")]
        public  Task<List<RoomDTO?>> ListRooms()=> adminService.ListRooms();
        [HttpGet("ListGuests")]
        public  Task<List<GuestDTO?>> ListGuests()=> adminService.ListGuests();
        [HttpGet("GetRoom")]
        public Task<RoomDTO?> GetRoom(int id)=> adminService.GetRoom(id);
    }
}
