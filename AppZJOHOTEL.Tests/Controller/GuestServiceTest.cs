using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public async Task ListGuests_Should_Return_Correct_Result()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DatabaseContext>().Options;
            A.CallTo(() => _context.Invoke()).Returns(new DatabaseContext(options));
            var expectedResult = new List<GuestDTO>()
        {
            new GuestDTO
            {
                Id = 1,
                Email = "example@mail.com",
                Password = "12345",
                Surname = "Smith"
            },
            new GuestDTO
            {
                Id = 2,
                Email = "example2@mail.com",
                Password = "54321",
                Surname = "Johnson"
            }
        };

            // Act
            var actualResult = await _sut.ListGuests();

            // Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }
    }
}
