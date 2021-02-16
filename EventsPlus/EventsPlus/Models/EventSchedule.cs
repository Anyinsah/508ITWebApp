using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class EventSchedule
    {
        public int EventScheduleID { get; set; }
        [Reqiuired]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public string Location { get; set; }
        public string Venu { get; set; }

        public int EventCompanyID { get; set; }
        public EventCompany Event { get; set; }




    }
}
