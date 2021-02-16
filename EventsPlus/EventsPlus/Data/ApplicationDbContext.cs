using EventsPlus.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventsPlus.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressCode> AddressCodes { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<ContactInformation> Contacts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCompany> EventCompanies { get; set; }
        public DbSet<EventSchedule> EventSchedules { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Address>().ToTable("Address");
            builder.Entity<AddressCode>().ToTable("AddressCode");
            builder.Entity<Attendee>().ToTable("Attendee");
            builder.Entity<ContactInformation>().ToTable("ContactInformation");
            builder.Entity<Employee>().ToTable("Employee");
            builder.Entity<EmployeeRole>().ToTable("EmployeeRole");
            builder.Entity<Event>().ToTable("Event");
            builder.Entity<EventCompany>().ToTable("EventCompany");
            builder.Entity<EventSchedule>().ToTable("EventSchedule");
            builder.Entity<Person>().ToTable("Person");
            builder.Entity<Ticket>().ToTable("Ticket");
            builder.Entity<AddressCode>().HasIndex(u => u.Postcode).IsUnique();
            builder.Entity<ContactInformation>().HasIndex(u => u.Number).IsUnique();
            builder.Entity<ContactInformation>().HasIndex(u => u.Email).IsUnique();




        } 

    }
}
