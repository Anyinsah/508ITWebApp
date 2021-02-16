using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class Attendee: Person
    {
        public int AttendeeID { get; set; }
        public int EventID { get; set; }
        public Event Event { get; set; }

    }
}
