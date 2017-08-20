namespace Bookshelf.Tests.Controllers
{
    using System;
    using Bookshelf.Controllers;
    using Bookshelf.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class RentalsControllerTests
    {
        private readonly Mock<IRentalService> rentalService = new Mock<IRentalService>();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RentalsController_BookServiceIsNull()
        {
            var given = new Prior
            {
                HasRentalService = false
            };

            this.CreateRentalsController(given);
        }

        private RentalsController CreateRentalsController(Prior given)
        {
            return new RentalsController(
                given.HasRentalService ? this.rentalService.Object : null);
        }

        internal class Prior
        {
            public bool HasRentalService { get; set; } = true;
        }
    }
}
