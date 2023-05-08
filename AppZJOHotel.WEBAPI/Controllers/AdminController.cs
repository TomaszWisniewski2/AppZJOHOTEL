using AppZJOHotel.Services.AdminService;
using AppZJOHotel.Services.GuestService;
using Microsoft.AspNetCore.Mvc;

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
        public Task<RoomTypeDTO> AddRoomType([FromBody] RoomTypeDTO dto)=> adminService.AddRoomType(dto);
        [HttpPost("AddRoom")]
        public Task<RoomDTO> AddRoom([FromBody] RoomDTO dto) => adminService.AddRoom(dto);
    }
}
