using System;
using Xunit;
using DeskBooker.Core.Domain;
using DeskBooker.Core.Processor;

namespace DeskBooker.Core.Test.Processor
{
    public class DeskBookingRequestProcessorTests
    {
        [Fact]
        public void ShouldReturnDeskBookingRequestValues()
        {
            // Arrange
            var request = new DeskBookingRequest
            {
                FirstName = "Adrian",
                LastName = "Castro",
                Email = "adrian.castrobeiro@plexus.es",
                Date = DateTime.Today
            };

            var processor = new DeskBookingRequestProcessor();

            // Act
            var result = processor.BookDesk(request);

            // Assert
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);
        }

        [Fact]
        public void ShouldThrowExceptionWhenRequestIsNull()
        {
            var processor = new DeskBookingRequestProcessor();

            var exception = Assert.Throws<ArgumentNullException>(() => processor.BookDesk(null));

            Assert.Equal("request", exception.ParamName);
        }
    }
}
