using EventsPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.ViewModels
{
    public class StreetAddressCodes
    {
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<AddressCode> AddressCodes { get; set; }

    }
}
