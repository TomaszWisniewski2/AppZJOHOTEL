using AppZJOHotel.DAL.Entities;
using AppZJOHotel.Services.GuestService;
using AppZJOHotel.WEBAPI.Db_Access;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AppZJOHotel.Services.AdminService
{
    public class AdminService: IAdminService
    {
        private readonly Func<DatabaseContext> context;

        public AdminService(Func<DatabaseContext> context)
        {

            this.context = context;
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
            
            room.RoomNumber = dto.RoomNumber;
            room.RoomPrice = dto.RoomPrice;
            room.RoomCapacity = dto.RoomCapacity;
            room.RoomPhoto = dto.RoomPhoto;
            room.RoomStatus = dto.RoomStatus;
            room.RoomTypeId = dto.RoomTypeId;
        }
        private static void UpdateRoomType(RoomType roomtype, RoomTypeDTO dto)
        {
            //roomtype.Id = dto.Id;
            roomtype.Type = dto.RoomType;
            
        }

        internal static readonly Expression<Func<Room, RoomDTO?>> RoomAddEditDTOExpression = x => new RoomDTO()
        {
            Id = x.Id,
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
    }
}
