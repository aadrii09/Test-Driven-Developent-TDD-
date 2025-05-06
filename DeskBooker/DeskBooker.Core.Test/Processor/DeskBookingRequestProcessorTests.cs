using System;
using Xunit;
using DeskBooker.Core.Domain;
using DeskBooker.Core.Processor;

namespace DeskBooker.Core.Test.Processor
{
    public class DeskBookingRequestProcessorTests
    {
        private readonly DeskBookingRequestProcessor _processor;

        public DeskBookingRequestProcessorTests()
        {
             this._processor = new DeskBookingRequestProcessor();
        }
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


            // Act
            var result = this._processor.BookDesk(request);

            // Assert
            Assert.Equal(request.FirstName, result.FirstName);
            Assert.Equal(request.LastName, result.LastName);
            Assert.Equal(request.Email, result.Email);
            Assert.Equal(request.Date, result.Date);
        }

        [Fact]
        public void ShouldThrowExceptionWhenRequestIsNull()
        {

            var exception = Assert.Throws<ArgumentNullException>(() => this._processor.BookDesk(null));

            Assert.Equal("request", exception.ParamName);
        }
    }
}
