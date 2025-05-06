using System;
using Xunit;
using DeskBooker.Core.Domain;
using DeskBooker.Core.Processor;

namespace DeskBooker.Core.Test.Processor
{
    public class DeskBookingRequestProcessorTests
    {
        private readonly DeskBookingRequest _request;
        private readonly DeskBookingRequestProcessor _processor;

        public DeskBookingRequestProcessorTests()
        {
            request = new DeskBookingRequest
            {
                FirstName = "Adrian",
                LastName = "Castro",
                Email = "adrian.castrobeiro@plexus.es",
                Date = DateTime.Today
            };

            this._processor = new DeskBookingRequestProcessor();
        }
        [Fact]
        public void ShouldReturnDeskBookingRequestValues()
        {
             var request = new DeskBookingRequest
            {
                FirstName = "Adrian",
                LastName = "Castro",
                Email = "adrian.castrobeiro@plexus.es",
                Date = DateTime.Today
            };

            var result = this._processor.BookDesk(_request);


            Assert.Equal(_request.FirstName, result.FirstName);
            Assert.Equal(_request.LastName, result.LastName);
            Assert.Equal(_request.Email, result.Email);
            Assert.Equal(_request.Date, result.Date);
        }

        [Fact]
        public void ShouldThrowExceptionWhenRequestIsNull()
        {

            var exception = Assert.Throws<ArgumentNullException>(() => this._processor.BookDesk(null));

            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldSaveDeskBooking()
        {

        }
    }
}
