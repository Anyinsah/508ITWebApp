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
    public class EventSchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventSchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EventSchedules
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EventSchedules.Include(e => e.Event);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EventSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSchedule = await _context.EventSchedules
                .Include(e => e.Event)
                .FirstOrDefaultAsync(m => m.EventScheduleID == id);
            if (eventSchedule == null)
            {
                return NotFound();
            }

            return View(eventSchedule);
        }

        // GET: EventSchedules/Create
        public IActionResult Create()
        {
            ViewData["EventCompanyID"] = new SelectList(_context.EventCompanies, "EventCompanyID", "EventCompanyID");
            return View();
        }

        // POST: EventSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventScheduleID,Date,Time,Location,Venu,EventCompanyID")] EventSchedule eventSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventCompanyID"] = new SelectList(_context.EventCompanies, "EventCompanyID", "EventCompanyID", eventSchedule.EventCompanyID);
            return View(eventSchedule);
        }

        // GET: EventSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSchedule = await _context.EventSchedules.FindAsync(id);
            if (eventSchedule == null)
            {
                return NotFound();
            }
            ViewData["EventCompanyID"] = new SelectList(_context.EventCompanies, "EventCompanyID", "EventCompanyID", eventSchedule.EventCompanyID);
            return View(eventSchedule);
        }

        // POST: EventSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventScheduleID,Date,Time,Location,Venu,EventCompanyID")] EventSchedule eventSchedule)
        {
            if (id != eventSchedule.EventScheduleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventScheduleExists(eventSchedule.EventScheduleID))
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
            ViewData["EventCompanyID"] = new SelectList(_context.EventCompanies, "EventCompanyID", "EventCompanyID", eventSchedule.EventCompanyID);
            return View(eventSchedule);
        }

        // GET: EventSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventSchedule = await _context.EventSchedules
                .Include(e => e.Event)
                .FirstOrDefaultAsync(m => m.EventScheduleID == id);
            if (eventSchedule == null)
            {
                return NotFound();
            }

            return View(eventSchedule);
        }

        // POST: EventSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventSchedule = await _context.EventSchedules.FindAsync(id);
            _context.EventSchedules.Remove(eventSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventScheduleExists(int id)
        {
            return _context.EventSchedules.Any(e => e.EventScheduleID == id);
        }
    }
}
