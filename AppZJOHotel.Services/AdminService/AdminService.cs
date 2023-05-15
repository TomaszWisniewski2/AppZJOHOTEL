using AppZJOHotel.DAL.Entities;
using AppZJOHotel.Services.GuestService;
using AppZJOHotel.WEBAPI.Db_Access;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace AppZJOHotel.Services.AdminService
{
    public class AdminService: IAdminService
    {
        private readonly Func<DatabaseContext> context;

        public AdminService(Func<DatabaseContext> context)
        {
            this.context = context;
        }

        public async Task<List<RoomDTO?>> ListRooms()
        {
            using var ctx = context();
            var q = ctx.Room.AsQueryable().AsNoTracking();
            var result = await q.Select(RoomListDTOExpression).ToListAsync();

            return result;
        }
        public async Task<List<GuestDTO?>> ListGuests()
        {
            using var ctx = context();
            var q = ctx.Guest.AsQueryable().AsNoTracking();
            var result = await q.Select(GuestListDTOExpression).ToListAsync();

            return result;
        }
        public async Task<string> DeleteRoom(RoomDTO dto)
        {
            using var ctx = context();
            if (!dto.Id.HasValue)
                return "null";
            Room? room = await ctx.Room.FindAsync(dto.Id.Value);
            if (room == null) return "null";
            ctx.Room.Remove(room);
            await ctx.SaveChangesAsync();
            return "done";
        }
        public async Task<RoomDTO?> EditRoom(RoomDTO dto)
        {
            using var ctx = context();
            if (!dto.Id.HasValue)
                return null;
            Room? room = await ctx.Room.FindAsync(dto.Id.Value);
            if (room == null) return null;
            UpdateRoom(room, dto);
            await ctx.SaveChangesAsync();
#pragma warning disable CS8603 // Possible null reference return.
            return RoomAddEditDTOExpression.Invoke(room);
#pragma warning disable CS8603 // Possible null reference return.
        }
        public async Task<RoomTypeDTO> AddRoomType(RoomTypeDTO dto)
        {
            using var ctx = context();
            RoomType roomtype = new();
            await ctx.RoomType.AddAsync(roomtype);
            UpdateRoomType(roomtype, dto);
            await ctx.SaveChangesAsync();

#pragma warning disable CS8603 // Possible null reference return.
            return RoomTypeAddDTOExpression.Invoke(roomtype);
#pragma warning disable CS8603 // Possible null reference return.
        }
        public async Task<RoomDTO> AddRoom(RoomDTO dto)
        {
            using var ctx = context();        
            Room room = new();         
            await ctx.Room.AddAsync(room);           
            UpdateRoom(room, dto);
            await ctx.SaveChangesAsync();
#pragma warning disable CS8603 // Possible null reference return.
            return RoomAddEditDTOExpression.Invoke(room);
#pragma warning disable CS8603 // Possible null reference return.
        }
        private static void UpdateRoom(Room room, RoomDTO dto)
        {
            
            room.RoomNumber = dto.RoomNumber!=0? dto.RoomNumber:room.RoomNumber;
            room.RoomPrice = dto.RoomPrice!=0? dto.RoomPrice:room.RoomPrice ;
            room.RoomCapacity =dto.RoomCapacity!=0? dto.RoomCapacity: room.RoomCapacity;
            room.RoomPhoto = dto.RoomPhoto!=null? dto.RoomPhoto: room.RoomPhoto;
            room.RoomStatus = dto.RoomStatus !=null? dto.RoomStatus:room.RoomStatus;
            room.RoomTypeId = dto.RoomTypeId !=0? dto.RoomTypeId:room.RoomTypeId;
        }
        private static void UpdateRoomType(RoomType roomtype, RoomTypeDTO dto)
        {
            //roomtype.Id = dto.Id;
            roomtype.Type = dto.RoomType;
            
        }

        internal static readonly Expression<Func<Room, RoomDTO?>> RoomAddEditDTOExpression = x => new RoomDTO()
        {
            Id = x.Id ,
            RoomNumber = x.RoomNumber,
            RoomPrice = x.RoomPrice,
            RoomCapacity = x.RoomCapacity,
            RoomPhoto = x.RoomPhoto,
            RoomStatus = x.RoomStatus,
            RoomTypeId = x.RoomTypeId
        };

        internal static readonly Expression<Func<RoomType, RoomTypeDTO?>> RoomTypeAddDTOExpression = x => new RoomTypeDTO()
        {
            Id = x.Id,
            RoomType=x.Type

        };
        internal static readonly Expression<Func<Guest, GuestDTO?>> GuestListDTOExpression = x => new GuestDTO()
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
    }
}
