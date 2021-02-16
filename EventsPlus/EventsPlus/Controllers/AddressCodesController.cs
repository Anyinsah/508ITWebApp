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
    public class AddressCodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AddressCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddressCodes.ToListAsync());
        }

        // GET: AddressCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressCode = await _context.AddressCodes
                .FirstOrDefaultAsync(m => m.AddressCodeID == id);
            if (addressCode == null)
            {
                return NotFound();
            }

            return View(addressCode);
        }

        // GET: AddressCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddressCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressCodeID,Postcode,Town,County")] AddressCode addressCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addressCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addressCode);
        }

        // GET: AddressCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressCode = await _context.AddressCodes.FindAsync(id);
            if (addressCode == null)
            {
                return NotFound();
            }
            return View(addressCode);
        }

        // POST: AddressCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressCodeID,Postcode,Town,County")] AddressCode addressCode)
        {
            if (id != addressCode.AddressCodeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addressCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressCodeExists(addressCode.AddressCodeID))
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
            return View(addressCode);
        }

        // GET: AddressCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addressCode = await _context.AddressCodes
                .FirstOrDefaultAsync(m => m.AddressCodeID == id);
            if (addressCode == null)
            {
                return NotFound();
            }

            return View(addressCode);
        }

        // POST: AddressCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addressCode = await _context.AddressCodes.FindAsync(id);
            _context.AddressCodes.Remove(addressCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressCodeExists(int id)
        {
            return _context.AddressCodes.Any(e => e.AddressCodeID == id);
        }
    }
}
