using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventsPlus.Data;
using EventsPlus.Models;
using EventsPlus.ViewModels;

namespace EventsPlus.Controllers
{
    public class AddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Addresses
        public async Task<IActionResult> Index_default()
        {
            var applicationDbContext = _context.Addresses.Include(a => a.AddressCode);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Addresses
        public ActionResult Index(int? id)
        {
            var viewModel = new StreetAddressCodes();
            viewModel.Addresses = _context.Addresses
              .Include(c => c.AddressCode)
              .OrderBy(c => c.StreetAddress);

            if (id != null)
            {
                ViewBag.addressID = id.Value;
                viewModel.Addresses = viewModel.AddressCodes.Where(
                  f => f.AddressCodeID == id.Value).Single().AddressCodes;
            }



            return View(viewModel);

        }

        // GET: Addresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.AddressCode)
                .FirstOrDefaultAsync(m => m.AddressID == id);
            if (address == null)
            {
                return NotFound();
            }


            ViewBag.Addresses = _context.AddressCodes
 .Include(c => c.AddressCodes).Where(c => c.AddressCodeID == id)
 .Single().AddressCodes;
            return View(address);

        }

        // GET: Addresses/Create
        public IActionResult Create()
        {
            ViewData["AddressCodeID"] = new SelectList(_context.AddressCodes, "AddressCodeID", "AddressCodeID");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressID,StreetAddress,AddressCodeID")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressCodeID"] = new SelectList(_context.AddressCodes, "AddressCodeID", "AddressCodeID", address.AddressCodeID);
            return View(address);
        }

        // GET: Addresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["AddressCodeID"] = new SelectList(_context.AddressCodes, "AddressCodeID", "AddressCodeID", address.AddressCodeID);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressID,StreetAddress,AddressCodeID")] Address address)
        {
            if (id != address.AddressID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.AddressID))
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
            ViewData["AddressCodeID"] = new SelectList(_context.AddressCodes, "AddressCodeID", "AddressCodeID", address.AddressCodeID);
            return View(address);
        }

        // GET: Addresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.AddressCode)
                .FirstOrDefaultAsync(m => m.AddressID == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.AddressID == id);
        }
    }
}
