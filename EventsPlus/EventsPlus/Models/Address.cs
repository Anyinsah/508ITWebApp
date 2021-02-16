using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public int AddressCodeID { get; set; }

        public AddressCode AddressCode { get; set; }


    }
}
