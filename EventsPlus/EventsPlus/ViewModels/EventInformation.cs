using EventsPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.ViewModels
{
    public class EventInformation
    {

        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<EventSchedule> EventSchedules { get; set; }
        public IEnumerable<EventCompany> EventCompanies { get; set; }

    }
}
