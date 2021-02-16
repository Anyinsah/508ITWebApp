using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventsPlus.Data;
using EventsPlus.Models;

namespace EventsPlus.Controllers
{
    public class AttendeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Attendees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Attendees.Include(a => a.Address).Include(a => a.ContactInformation).Include(a => a.Event);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Attendees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendee = await _context.Attendees
                .Include(a => a.Address)
                .Include(a => a.ContactInformation)
                .Include(a => a.Event)
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (attendee == null)
            {
                return NotFound();
            }

            return View(attendee);
        }

        // GET: Attendees/Create
        public IActionResult Create()
        {
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID");
            ViewData["ContactInformationID"] = new SelectList(_context.Contacts, "ContactInformationID", "ContactInformationID");
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID");
            return View();
        }

        // POST: Attendees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttendeeID,EventID,PersonID,FirstName,SecondName,AddressID,ContactInformationID")] Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attendee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", attendee.AddressID);
            ViewData["ContactInformationID"] = new SelectList(_context.Contacts, "ContactInformationID", "ContactInformationID", attendee.ContactInformationID);
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID", attendee.EventID);
            return View(attendee);
        }

        // GET: Attendees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendee = await _context.Attendees.FindAsync(id);
            if (attendee == null)
            {
                return NotFound();
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", attendee.AddressID);
            ViewData["ContactInformationID"] = new SelectList(_context.Contacts, "ContactInformationID", "ContactInformationID", attendee.ContactInformationID);
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID", attendee.EventID);
            return View(attendee);
        }

        // POST: Attendees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttendeeID,EventID,PersonID,FirstName,SecondName,AddressID,ContactInformationID")] Attendee attendee)
        {
            if (id != attendee.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendeeExists(attendee.PersonID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", attendee.AddressID);
            ViewData["ContactInformationID"] = new SelectList(_context.Contacts, "ContactInformationID", "ContactInformationID", attendee.ContactInformationID);
            ViewData["EventID"] = new SelectList(_context.Events, "EventID", "EventID", attendee.EventID);
            return View(attendee);
        }

        // GET: Attendees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendee = await _context.Attendees
                .Include(a => a.Address)
                .Include(a => a.ContactInformation)
                .Include(a => a.Event)
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (attendee == null)
            {
                return NotFound();
            }

            return View(attendee);
        }

        // POST: Attendees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendee = await _context.Attendees.FindAsync(id);
            _context.Attendees.Remove(attendee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttendeeExists(int id)
        {
            return _context.Attendees.Any(e => e.PersonID == id);
        }
    }
}
