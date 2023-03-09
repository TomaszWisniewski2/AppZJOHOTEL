using AppZJOHotel.Services.GuestService;
using AppZJOHotel.Types;
using Microsoft.AspNetCore.Mvc;

namespace AppZJOHotel.WEBAPI.Controllers
{
    public class GuestController : ControllerBase
    {
        private readonly IGuestService guestService;

        public GuestController(IGuestService guestService)
        {
            this.guestService = guestService;
        }
        [HttpGet]
        public Task<List<GuestDTO?>> List() => guestService.ListGuests();

    }
}
