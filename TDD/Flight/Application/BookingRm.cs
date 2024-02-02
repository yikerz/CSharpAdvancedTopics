using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class BookingRm
    {
        public string Email { get; set; }
        public int NumberOfSeats { get; set; }

        public BookingRm(string email, int numberOfSeats)
        {
            Email = email;
            NumberOfSeats = numberOfSeats;
        }
    }
}
