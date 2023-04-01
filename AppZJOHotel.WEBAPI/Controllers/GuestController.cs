using AppZJOHotel.DAL.Entities;
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
    }
}
