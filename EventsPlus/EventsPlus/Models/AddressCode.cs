using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class AddressCode
    {
        public int AddressCodeID { get; set; }

        public string Postcode { get; set; }

        public string Town { get; set; }

        public string County { get; set; }
        public IEnumerable<Address> AddressCodes { get; internal set; }
    }
}
