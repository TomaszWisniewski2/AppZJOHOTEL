using AppZJOHotel.DAL;
using AppZJOHotel.DAL.Entities;
using AppZJOHotel.Services.AdminService;
using AppZJOHotel.WEBAPI.Db_Access;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AppZJOHotel.Services.GuestService;

public class GuestService : IGuestService
{
    private readonly Func<DatabaseContext> context;

    public GuestService(Func<DatabaseContext> context)
    {

        this.context = context;
    }

    public async Task<String> Payment(int enu, int id)
    {
        using var ctx = context();
        Booking? bookink = await ctx.Booking.FindAsync(id);
        if (bookink == null) return "null";
        bookink.PaymentType = (Common.Enums.PaymentType)enu;
        await ctx.SaveChangesAsync();
        return "done";
    }
    public async Task<BookingDTO?> GetBooking(int id)
    {
        using var ctx = context();
        var q = ctx.Booking.AsQueryable().AsNoTracking().Where(x=>x.Id==id);
        var result = await q.Select(BookingAddEditDTOExpression).FirstAsync();

        return result;
    }
    public async Task<string> DeleteBooking(int id)
    {
        using var ctx = context();
        if (id == 0)
            return "null";
        Booking? booking = await ctx.Booking.FindAsync(id);
        if (booking == null) return "null";
        ctx.Booking.Remove(booking);
        await ctx.SaveChangesAsync();
        return "done";
    }
    public async Task<EditBookingDTO> EditBookink(EditBookingDTO dto)
    {
        using var ctx = context();
        if (!dto.Id.HasValue)
            return null;
        Booking? bookink = await ctx.Booking.FindAsync(dto.Id.Value);
        if (bookink == null) return null;
        BookingEdit(bookink, dto);
        await ctx.SaveChangesAsync();
#pragma warning disable CS8603 // Possible null reference return.
        return BookingEditDTOExpression.Invoke(bookink);
#pragma warning disable CS8603 // Possible null reference return.

    }
    public async Task<BookingDTO> BookinkRoom(BookingDTO dto)
    {
        using var ctx = context();
        Booking booking = new();
        await ctx.Booking.AddAsync(booking);
        UpdateBooking(booking, dto);
        await ctx.SaveChangesAsync();
#pragma warning disable CS8603 // Possible null reference return.
        return BookingAddEditDTOExpression.Invoke(booking);
#pragma warning restore CS8603 // Possible null reference return.
    }
    public async Task<List<RoomDTO?>> ListRooms()
    {
        using var ctx = context();
        var q = ctx.Room.AsQueryable().AsNoTracking();
        var result = await q.Select(RoomListDTOExpression).ToListAsync();

        return result;
    }
    public async Task<int> Login(LoginDTO dto)
    {
        using var ctx = context();
        var q = ctx.Guest.Where(x => x.Email == dto.Email && x.Password == dto.Password);
        var r =await q.FirstAsync();
        return r.Id ;
    }

    public async Task<List<GuestDTO?>> ListGuests()
    {
        using var ctx = context();
        var q = ctx.Guest.AsQueryable().AsNoTracking();
        var result = await q.Select(GuestListDTOExpression).ToListAsync();

        return result;
    }
    
    public async Task<GuestDTO> RegisterGuest(GuestDTO dto)
    {
        using var ctx = context();
        Guest guest = new();       
        await ctx.Guest.AddAsync(guest);
        Update(guest, dto);
        await ctx.SaveChangesAsync();

#pragma warning disable CS8603 // Possible null reference return.
        return GuestAddEditDTOExpression.Invoke(guest);
#pragma warning restore CS8603 // Possible null reference return.

    }
    public async Task<GuestDTO?> EditGuest(GuestDTO dto)
    {
        using var ctx = context();
        if (!dto.Id.HasValue)
            return null;
        Guest? guest = await ctx.Guest.FindAsync(dto.Id.Value);
        if (guest == null) return null;
        Update(guest, dto);
        await ctx.SaveChangesAsync();

        return GuestAddEditDTOExpression.Invoke(guest);

    }
    private static void Update(Guest guest, GuestDTO dto)
    {
        guest.Name = dto.Name ?? guest.Name;
        guest.Email = dto.Email ?? guest.Email;
        guest.Password = dto.Password ?? guest.Password;
        guest.Surname = dto.Surname ?? guest.Surname;

    }
    private static void UpdateBooking(Booking booking, BookingDTO dto)
    {
        booking.GuestId = dto.GuestId ?? booking.GuestId;
        booking.RoomId = dto.RoomId ?? booking.RoomId;
        booking.BookingTo = dto.BookingTo ?? booking.BookingTo;
        booking.BookingFrom = dto.BookingFrom ?? booking.BookingFrom;

    }
    private static void BookingEdit(Booking booking, EditBookingDTO dto)
    {
        //booking.GuestId = dto.GuestId ?? booking.GuestId;
        //booking.Id = dto.Id ?? booking.Id;
        booking.RoomId = dto.RoomId ?? booking.RoomId;
        booking.BookingTo = dto.BookingTo ?? booking.BookingTo;
        booking.BookingFrom = dto.BookingFrom ?? booking.BookingFrom;

    }
    // to niżej ma być na dole
    #region Expressions
    internal static readonly Expression<Func<Guest, GuestDTO?>> GuestListDTOExpression = x => new GuestDTO()
    {
        Id = x.Id,
        Email = x.Email,
        Password = x.Password,
        Surname = x.Surname,
        Name = x.Name
    };

    internal static readonly Expression<Func<Guest, GuestDTO?>> GuestAddEditDTOExpression = x => new GuestDTO()
    {
        Id = x.Id,
        Email = x.Email,
        Password = x.Password,
        Surname = x.Surname,
        Name = x.Name
    };
    internal static readonly Expression<Func<Room, RoomDTO?>> RoomListDTOExpression = x => new RoomDTO()
    {
        Id = x.Id,
        RoomNumber = x.RoomNumber,
        RoomPrice = x.RoomPrice,
        RoomCapacity = x.RoomCapacity,
        RoomPhoto = x.RoomPhoto,
        RoomStatus = x.RoomStatus,
        RoomTypeId = x.RoomTypeId
    };
    internal static readonly Expression<Func<Booking, BookingDTO?>> BookingAddEditDTOExpression = x => new BookingDTO()
    {
        GuestId = x.GuestId,
        RoomId = x.RoomId,
        BookingFrom = x.BookingFrom,
        BookingTo = x.BookingTo
    };

    internal static readonly Expression<Func<Booking, EditBookingDTO?>> BookingEditDTOExpression = x => new EditBookingDTO()
    {
        
        RoomId = x.RoomId,
        BookingFrom = x.BookingFrom,
        BookingTo = x.BookingTo
    };
    #endregion
}
