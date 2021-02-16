using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class Event
    {
        public int EventID { get; set; }
        [Required]
        [Display(Name = "Event")]
        public string EventName { get; set; }

        public int EventScheduleID { get; set; }
        public EventSchedule EventSchedule { get; set; }

    }
}
