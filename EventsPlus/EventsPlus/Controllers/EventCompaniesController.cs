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
    public class EventCompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventCompaniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventCompanies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EventCompanies.Include(e => e.Address).Include(e => e.ContactInformation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EventCompanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventCompany = await _context.EventCompanies
                .Include(e => e.Address)
                .Include(e => e.ContactInformation)
                .FirstOrDefaultAsync(m => m.EventCompanyID == id);
            if (eventCompany == null)
            {
                return NotFound();
            }

            return View(eventCompany);
        }

        // GET: EventCompanies/Create
        public IActionResult Create()
        {
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID");
            ViewData["ContactInformationID"] = new SelectList(_context.Contacts, "ContactInformationID", "ContactInformationID");
            return View();
        }

        // POST: EventCompanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventCompanyID,CompanyName,AddressID,ContactInformationID")] EventCompany eventCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", eventCompany.AddressID);
            ViewData["ContactInformationID"] = new SelectList(_context.Contacts, "ContactInformationID", "ContactInformationID", eventCompany.ContactInformationID);
            return View(eventCompany);
        }

        // GET: EventCompanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventCompany = await _context.EventCompanies.FindAsync(id);
            if (eventCompany == null)
            {
                return NotFound();
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", eventCompany.AddressID);
            ViewData["ContactInformationID"] = new SelectList(_context.Contacts, "ContactInformationID", "ContactInformationID", eventCompany.ContactInformationID);
            return View(eventCompany);
        }

        // POST: EventCompanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventCompanyID,CompanyName,AddressID,ContactInformationID")] EventCompany eventCompany)
        {
            if (id != eventCompany.EventCompanyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventCompanyExists(eventCompany.EventCompanyID))
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
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", eventCompany.AddressID);
            ViewData["ContactInformationID"] = new SelectList(_context.Contacts, "ContactInformationID", "ContactInformationID", eventCompany.ContactInformationID);
            return View(eventCompany);
        }

        // GET: EventCompanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventCompany = await _context.EventCompanies
                .Include(e => e.Address)
                .Include(e => e.ContactInformation)
                .FirstOrDefaultAsync(m => m.EventCompanyID == id);
            if (eventCompany == null)
            {
                return NotFound();
            }

            return View(eventCompany);
        }

        // POST: EventCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventCompany = await _context.EventCompanies.FindAsync(id);
            _context.EventCompanies.Remove(eventCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventCompanyExists(int id)
        {
            return _context.EventCompanies.Any(e => e.EventCompanyID == id);
        }
    }
}
