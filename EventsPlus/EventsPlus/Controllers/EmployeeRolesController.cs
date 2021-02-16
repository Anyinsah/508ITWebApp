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
    public class EmployeeRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeRoles.ToListAsync());
        }

        // GET: EmployeeRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRole = await _context.EmployeeRoles
                .FirstOrDefaultAsync(m => m.EmployeeRoleID == id);
            if (employeeRole == null)
            {
                return NotFound();
            }

            return View(employeeRole);
        }

        // GET: EmployeeRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeRoleID,Role")] EmployeeRole employeeRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeRole);
        }

        // GET: EmployeeRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRole = await _context.EmployeeRoles.FindAsync(id);
            if (employeeRole == null)
            {
                return NotFound();
            }
            return View(employeeRole);
        }

        // POST: EmployeeRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeRoleID,Role")] EmployeeRole employeeRole)
        {
            if (id != employeeRole.EmployeeRoleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeRoleExists(employeeRole.EmployeeRoleID))
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
            return View(employeeRole);
        }

        // GET: EmployeeRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRole = await _context.EmployeeRoles
                .FirstOrDefaultAsync(m => m.EmployeeRoleID == id);
            if (employeeRole == null)
            {
                return NotFound();
            }

            return View(employeeRole);
        }

        // POST: EmployeeRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeRole = await _context.EmployeeRoles.FindAsync(id);
            _context.EmployeeRoles.Remove(employeeRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeRoleExists(int id)
        {
            return _context.EmployeeRoles.Any(e => e.EmployeeRoleID == id);
        }
    }
}
