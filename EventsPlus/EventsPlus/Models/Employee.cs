using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Models
{
    public class Employee: Person
    {
        public int EmployeeID { get; set; }

        public int EmployeeRoleID { get; set; }
        public EmployeeRole EmployeeRole { get; set; }
    }
}
