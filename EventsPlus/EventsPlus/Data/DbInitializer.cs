using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsPlus.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();   
        }
    }
}
