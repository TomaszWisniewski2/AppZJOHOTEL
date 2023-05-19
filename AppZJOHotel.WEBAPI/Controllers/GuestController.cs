using AppZJOHotel.DAL.Entities;
using AppZJOHotel.Services.AdminService;
using AppZJOHotel.Services.GuestService;
using AppZJOHotel.Types;
using Microsoft.AspNetCore.Mvc;

namespace AppZJOHotel.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService guestService;

        public GuestController(IGuestService guestService)
        {
            this.guestService = guestService;
        }
        [HttpGet("List")]
        public Task<List<GuestDTO?>> List() => guestService.ListGuests();

        [HttpPost("Register")]
        public Task<GuestDTO> Register([FromBody] GuestDTO guestDTO) => guestService.RegisterGuest(guestDTO);

        [HttpPut("EditGuest")]
        public Task<GuestDTO?> EditGuest([FromBody] GuestDTO guestDTO) => guestService.EditGuest(guestDTO);

        [HttpPut("Login")]
        public Task<int> Login([FromBody] LoginDTO dto) => guestService.Login(dto);

        [HttpGet("ListRooms")]
        public Task<List<RoomDTO?>> ListRooms() => guestService.ListRooms();

        [HttpPost("Booking")]
        public Task<BookingDTO> BookinkRoom([FromBody] BookingDTO dto) => guestService.BookinkRoom(dto);

        [HttpPut("EditBookink")]
        public Task<EditBookingDTO> EditBookink([FromBody] EditBookingDTO dto) => guestService.EditBookink(dto);
        
        [HttpPost("DeleteBooking")]
        public Task<string> DeleteBooking(int id)=> guestService.DeleteBooking(id);

        [HttpGet("GetBooking")]
        public Task<BookingDTO?> GetBooking(int id) => guestService.GetBooking(id);

        [HttpPost("Payment")]
        public Task<String> Payment(int enu, int id) => guestService.Payment(enu, id);
    }
}
