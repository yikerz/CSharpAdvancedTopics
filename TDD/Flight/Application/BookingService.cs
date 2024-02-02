using Data;

namespace Application
{
    public class BookingService
    {
        public Entities Entities { get; set; }
        public BookingService(Entities entities)
        {
            Entities = entities;
        }
        public void Book(BookingDto bookingDto)
        {
            var flight = Entities.Flights.Find(bookingDto.FlightId);
            flight.Book(bookingDto.Email, bookingDto.NumberOfSeats);
            Entities.SaveChanges();
        }

        public IEnumerable<BookingRm> FindBookings(Guid flightId)
        {
            return Entities.Flights
                .Find(flightId)
                .BookingList
                .Select(booking => new BookingRm(
                            booking.Email,
                            booking.numberOfSeats
                        ));
        }

        public object CheckSeatCapacity(Guid flightId)
        {
            return Entities.Flights.Find(flightId).SeatCapacity;
        }

        public void CancelBooking(CancelBookingDto cancelBookingDto)
        {
            var flight = Entities.Flights.Find(cancelBookingDto.FlightId);
            flight.CancelBooking(cancelBookingDto.Email, cancelBookingDto.NumberOfSeats);
            Entities.SaveChanges();
        }
    }
}
