﻿namespace DeskBooker.Core.Domain
{
 public class DeskBookingRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required DateTime Date { get; set; }
    }
}