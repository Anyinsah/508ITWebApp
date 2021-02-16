using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class EventCompany
    {
        public int EventCompanyID { get; set; }
        [Required]
        [Display(Name = "Organizer")]
        
        public string CompanyName { get; set; }

        public int AddressID { get; set; }
        public Address Address { get; set; }
        public int ContactInformationID { get; set; }
        public ContactInformation? ContactInformation { get; set; }
    }
}
