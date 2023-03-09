using AppZJOHotel.DAL;
using AppZJOHotel.DAL.Entities;
using AppZJOHotel.WEBAPI.Db_Access;
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


    public async Task<List<GuestDTO?>> ListGuests()
    {
        using var ctx = context();
        var q = ctx.Guest.AsQueryable().AsNoTracking().Where(x=>x.Id>2);
        var result = await q.Select(GuestListDTOExpression).ToListAsync();
   
        return result;
    }

    // to niżej ma być na dole
    #region Expressions
    internal static readonly Expression<Func<Guest, GuestDTO?>> GuestListDTOExpression = x => new GuestDTO()
    {
        Id = x.Id,
        Email = x.Email,
        Password = x.Password,
        Surname = x.Surname
    };
    #endregion
}
