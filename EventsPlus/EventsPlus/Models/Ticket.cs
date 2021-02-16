using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }


        [Required]
        public int Quantity { get; set; }
        
        public int EventID { get; set; }
        public Event Event { get; set; }

    }
}
