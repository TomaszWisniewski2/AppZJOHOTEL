using AppZJOHotel.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppZJOHotel.WEBAPI.Db_Access
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DbSet<Guest> Guest { get; set; }
        public DbSet<Booking> Booking { get; set; }       
        public DbSet<Room> Room { get; set; }      
        public DbSet<RoomType> RoomType { get; set; }
    }
}
