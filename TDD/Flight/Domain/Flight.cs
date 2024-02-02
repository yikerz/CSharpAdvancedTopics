
namespace Domain
{
    public class Flight
    {
        // new() can automatically detect data type
        private List<Booking> bookingList = new();
        public List<Booking> BookingList => bookingList;
        public int SeatCapacity { get; set; }
        public Guid Id { get; }

        [Obsolete("Needed for EF")]
        public Flight() { }

        public Flight(int seatCapacity)
        {
            SeatCapacity = seatCapacity;
        }

        public object? Book(string email, int numberOfSeats)
        {
            if (numberOfSeats <= SeatCapacity)
            {
                SeatCapacity -= numberOfSeats;
                bookingList.Add(new Booking(email, numberOfSeats));
                return null;
            }
            return new OverbookingError();
        }

        public object? CancelBooking(string email, int numberOfSeats)
        {
            if (!bookingList.Any(booking => booking.Email.Equals(email)))
            { 
                return new BookingNotFoundError();
            }
            SeatCapacity += numberOfSeats;
            return null;
        }
    }
}
