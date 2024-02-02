using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CancelBookingDto
    {
        public Guid FlightId { get; }
        public string Email { get; set; }
        public int NumberOfSeats { get; set; }

        public CancelBookingDto(Guid flightId, string email, int numberOfSeats)
        {
            FlightId = flightId;
            Email = email;
            NumberOfSeats = numberOfSeats;
        }
    }
}
