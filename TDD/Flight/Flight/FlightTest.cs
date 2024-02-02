using Domain;
using FluentAssertions;

namespace FlightTest
{
    public class FlightTest
    {
        [Fact]
        public void Flight_Booking_1_Seat_Remain_2_Seats()
        {
            Flight flight = new Flight(seatCapacity: 3);
            flight.Book("abc123@gmail.com", 1);
            flight.SeatCapacity.Should().Be(2);
        }
        [Fact]
        public void Avoids_Overbooking()
        {
            // Given
            Flight flight = new Flight(seatCapacity:3);
            // When
            var res = flight.Book("testing@gmail.com", 4);
            // Then
            res.Should().BeOfType<OverbookingError>();

        }
        [Fact]
        public void Books_Flights_Successfully()
        {
            var flight = new Flight(seatCapacity:3);
            var error = flight.Book("test@gmail.com", 2);
            error.Should().BeNull();
        }
        [Theory]
        [InlineData(3,2)]
        [InlineData(4,1)]
        [InlineData(10,8)]
        public void Flight_Booking_Parameterized(int seatCapacity, int numberOfBookings)
        {
            Flight flight = new Flight(seatCapacity: seatCapacity);
            flight.Book("abc123@gmail.com", numberOfBookings);
            flight.SeatCapacity.Should().Be(seatCapacity - numberOfBookings);
        }
        [Fact]
        public void Verify_Booking()
        {
            // Given
            var flight = new Flight(seatCapacity: 3);
            // When
            flight.Book("test@gmail.com", 2);
            // Then
            flight.BookingList.Should().ContainEquivalentOf(new Booking("test@gmail.com", 2));
        }
        [Theory]
        [InlineData(3,1,1,3)]
        public void Canceling_Bookings_Frees_Up_Seats(
                int initialCapacity,
                int numberOfSeatsToBook,
                int numberOfSeatsToCancel,
                int remainingCapacity
            )
        {
            // Given
            var flight = new Flight(seatCapacity: initialCapacity);
            // When
            flight.Book("test@gmail.com", numberOfSeatsToBook);
            flight.CancelBooking("test@gmail.com", numberOfSeatsToCancel);
            // Then
            flight.SeatCapacity.Should().Be(remainingCapacity);

        }
        [Fact]
        public void Doesnt_cancel_bookings_for_passengers_who_have_not_booked()
        {
            // Given
            var flight = new Flight(3);
            // When
            var err = flight.CancelBooking("nonexist@gmail.com", 2);
            // Then 
            err.Should().BeOfType<BookingNotFoundError>();
        }
        [Fact]
        public void Returns_null_when_successfully_cancels_booking()
        {
            // Given
            var flight = new Flight(3);
            // When
            flight.Book("test@gmail.com", 1);
            var err = flight.CancelBooking("test@gmail.com", 1);
            // Then 
            err.Should().BeNull();
        }
    }
}