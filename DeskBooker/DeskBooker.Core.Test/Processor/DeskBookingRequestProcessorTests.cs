using System;
using Xunit;
using DeskBooker.Core.Domain;
using DeskBooker.Core.Processor;
using Moq;
using DeskBooker.Core.DataInterface;

namespace DeskBooker.Core.Test.Processor
{
    public class DeskBookingRequestProcessorTests
    {
        private readonly DeskBookingRequest _request;
        private readonly Mock<IDeskBookingRepository> _deskBookingRepositoryMock;
        private readonly DeskBookingRequestProcessor _processor;

        public DeskBookingRequestProcessorTests()
        {
            this._request = new DeskBookingRequest
            {
                FirstName = "Adrian",
                LastName = "Castro",
                Email = "adrian.castrobeiro@plexus.es",
                Date = DateTime.Today
            };

            this._deskBookingRepositoryMock = new Mock<IDeskBookingRepository>();
            this._processor = new DeskBookingRequestProcessor(this._deskBookingRepositoryMock.Object);
        }

        [Fact]
        public void ShouldReturnDeskBookingRequestValues()
        {
            // Act
            var result = this._processor.BookDesk(this._request);

            // Assert
            Assert.Equal(this._request.FirstName, result.FirstName);
            Assert.Equal(this._request.LastName, result.LastName);
            Assert.Equal(this._request.Email, result.Email);
            Assert.Equal(this._request.Date, result.Date);
        }

        [Fact]
        public void ShouldThrowExceptionWhenRequestIsNull()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => this._processor.BookDesk(null));
            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldSaveDeskBooking()
        {
            DeskBooking savedDeskBooking = null;

            this._deskBookingRepositoryMock.Setup(x => x.Save(It.IsAny<DeskBooking>()))
                .Callback<DeskBooking>(x =>
                {
                    savedDeskBooking = x;
                });

            // Act
            this._processor.BookDesk(this._request);

            // Assert
            this._deskBookingRepositoryMock.Verify(x => x.Save(It.IsAny<DeskBooking>()), Times.Once);
            Assert.NotNull(savedDeskBooking);
            Assert.Equal(this._request.FirstName, savedDeskBooking.FirstName);
            Assert.Equal(this._request.LastName, savedDeskBooking.LastName);
            Assert.Equal(this._request.Email, savedDeskBooking.Email);
            Assert.Equal(this._request.Date, savedDeskBooking.Date);
        }
    }
}
