using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class Person
    {

        public int PersonID { get; set; }

        
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string SecondName { get; set; }

        public int AddressID { get; set; }
        public Address Address { get; set; }

        [Display(Name = "Contact Information")]
        public int ContactInformationID { get; set; }
        public ContactInformation ContactInformation { get; set; }
    }
}
