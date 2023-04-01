using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppZJOHotel.DAL.Entities;
using AppZJOHotel.Services.GuestService;
using AppZJOHotel.WEBAPI.Db_Access;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace AppZJOHOTEL.Tests.Controller
{
    public class GuestServiceTest
    {
        private readonly Func<DatabaseContext> _context;
        private GuestService _sut;

        public GuestServiceTest()
        {
            _context = A.Fake<Func<DatabaseContext>>();
            _sut = new GuestService(_context);
        }

        [Fact]
        public async Task ListGuests_ShouldBeAbleToReadDataFromDatabase()
        {
            // Arrange
            var guests = new List<Guest>
            {
                new Guest { Id = 1, Email = "email1@example.com", Password = "Password1", Surname = "Surname1" },
                new Guest { Id = 2, Email = "email2@example.com", Password = "Password2", Surname = "Surname2" },
                new Guest { Id = 3, Email = "email3@example.com", Password = "Password3", Surname = "Surname3" },
            };
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "ListGuestsTestDatabase")
                .Options;
            using var context = new DatabaseContext(options);
            context.Guest.AddRange(guests);
            context.SaveChanges();
            // making our fake database context
            var fakeContext = new Func<DatabaseContext>(() => context);
            var service = new GuestService(fakeContext);

            // Act
            var result = await service.ListGuests();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal("email1@example.com", result[0].Email);
            Assert.Equal("Password2", result[1].Password);
            Assert.Equal("Surname3", result[2].Surname);
        }

        //[Fact]
        //public async void RegisterGuest_ShouldReturnGuestDTO()
        //{
        //    // Arrange
        //    var options = new DbContextOptionsBuilder<DatabaseContext>()
        //        .UseInMemoryDatabase(databaseName: "RegisterGuest_ShouldReturnGuestDTO")
        //        .Options;

        //    var guestData = new GuestDTO
        //    {
        //        Name = "John Doe",
        //        Email = "qwe",
        //        Password = "qwe",
        //        Surname = "qawe",

        //    };

        //    // Act
        //    using (var context = new DatabaseContext(options))
        //    {
        //        var fakeContext = new Func<DatabaseContext>(() => context);
        //        var guestService = new GuestService(fakeContext);
        //        var result = await guestService.RegisterGuest(guestData);
        //    }

        //    // Assert
        //    using (var context = new DatabaseContext(options))
        //    {
        //        Assert.NotNull(context.Guest.Find(guestData.Name));
        //    }
        //}
        [Fact]
        public async void RegisterGuest_Returns_Expected_GuestDTO()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "ListGuestsTestDatabase")
                .Options;
            using var context = new DatabaseContext(options);
            
            // making our fake database context
            var fakeContext = new Func<DatabaseContext>(() => context);

            var guestService = new GuestService(fakeContext);
            var guestDTO = new GuestDTO
            {
                Name = "TestName",
                Surname = "TestSurname",
                Email = "test@test.com",
                Password = "testPassword"
            };

            //Act
            var result = await guestService.RegisterGuest(guestDTO);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(guestDTO.Name, result.Name);
            Assert.Equal(guestDTO.Surname, result.Surname);
            Assert.Equal(guestDTO.Email, result.Email);
            Assert.Equal(guestDTO.Password, result.Password);
        }
    }
}
