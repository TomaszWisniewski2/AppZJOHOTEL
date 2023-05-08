using AppZJOHotel.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppZJOHotel.Services.GuestService
{
    public class GuestDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        //public int? Number { get; set; }

    }
}
