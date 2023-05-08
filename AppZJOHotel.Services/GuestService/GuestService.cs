using AppZJOHotel.DAL;
using AppZJOHotel.DAL.Entities;
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
    //public async Task<GuestDTO> Booking(GuestDTO guestDTO)
    //{

    //}
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
    #endregion
}
