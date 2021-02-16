using EventsPlus.Controllers;
using EventsPlus.Data;
using EventsPlus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EventsPlus.NewTests.Controllers
{
    public class AddressControllerTests
    {
        private async Task<ApplicationDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
              .Options;
            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();
            if (await databaseContext.Users.CountAsync() <= 0)
            {
                databaseContext.Addresses.AddRange(address());
                databaseContext.AddressCodes.AddRange(addresscode());
                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }

        private List<Address> address()
        {
            return new List<Address>
        {
                
                new Address {AddressID = 1, StreetAddress = "247 Old Lodge Lane", AddressCodeID = addresscode().Single(s => s.Postcode == "CR8 4AZ").AddressCodeID},
                new Address {AddressID = 2, StreetAddress = "25 Lansdowne Street", AddressCodeID = addresscode().Single(s => s.Postcode == "CV2 4FN").AddressCodeID}

            };



        }
        private List<AddressCode> addresscode()
        {
            return new List<AddressCode>
            {

          new AddressCode { AddressCodeID = 1, Postcode = "CR8 4AZ",   Town = "Croydon", County = "Greater London" },
          new AddressCode { AddressCodeID = 2, Postcode = "CV2 4FN", Town = "Coventry", County = "West Midlands" }
             };

        }
        [Fact]
        public async Task Index_ReturnsAViewResult_ListOfAddresses()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var addressesController = new AddressesController(dbContext);
            //Act
            var result = await addressesController.Index_default();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Address>>(
              viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
        [Fact]
        public async Task Details_ReturnsViewResultWithFootballClubModel()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var addressControler = new AddressesController(dbContext);

            //Act
            var result = await addressControler.Details(1);
            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Address>(
            viewResult.ViewData.Model);
            Assert.Equal("247 Old Lodge Lane", model.StreetAddress);
            Assert.Equal(1, model.AddressID);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(4)]
        public async Task Edit_ReturnsHttpNotFoundWhenClubIdNotFound(int addressID)
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var addressesController = new AddressesController(dbContext);
            //Act
            var result = await addressesController.Edit(addressID);

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }




    }
}

