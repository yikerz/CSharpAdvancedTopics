using FluentAssertions;
using System.ComponentModel.DataAnnotations;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class FlightApplicationSpec
    {
        readonly Entities entities = new Entities(new DbContextOptionsBuilder<Entities>()
                    .UseInMemoryDatabase("Flights").Options);
        readonly BookingService bookingService;

        public FlightApplicationSpec()
        {
            bookingService = new BookingService(entities);
        }

        [Theory]
        [InlineData(4, "ab@gmail.com", 1)]
        [InlineData(6, "abcd@gmail.com", 3)]
        public void Books_flights(int seatCapacity, string email, int bookingSeats)
        {
            // Given
            Flight flight = new Flight(seatCapacity);
            entities.Flights.Add(flight);
            // When
            bookingService.Book(new BookingDto(
                flightId: flight.Id,
                email: email,
                numberOfSeats: bookingSeats));
            // Then
            bookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(new BookingRm(
                email: email,
                numberOfSeats: bookingSeats));
        }
        [Theory]
        [InlineData(3)]
        public void Cancels_booking(int seatCapacity)
        {
            // Given
            Flight flight = new Flight(seatCapacity);
            entities.Flights.Add(flight);
            bookingService.Book(new BookingDto(flight.Id, "test@gmail.com", 2));
            // When
            bookingService.CancelBooking(new CancelBookingDto(flight.Id, "test@gmail.com", 2));
            // Then
            bookingService.CheckSeatCapacity(flight.Id).Should().Be(seatCapacity);

        }
    }
}