using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooker.Core.Test.Processor
{
    internal class DeskBookingRequestProcessorTests
    {
        [Fact]
        public void ShouldReturnDeskBookingRequestValues()
        {
            // Arrange
            var request = new DeskBookingRequest()
            {
                FirstName = "Adrian",
                LastName = "Castro",
                Email = "adrian.castrobeiro@plexus.es",
                Date = new DateTime(205, 1, 15),
            };
            var processor = new DeskBookingRequestProcessor();


            // Act
            DeskBookingResult result = processor.BookDesk(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);
        }
    }
}
