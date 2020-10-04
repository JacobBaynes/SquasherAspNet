using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Squasher.Data;
using Squasher.Models;

namespace Squasher.Controllers
{
    public class SquasherController : Controller
    {
        private readonly SquasherDbContext _context;

        public SquasherController(SquasherDbContext context)
        {
            _context = context;
        }

        // GET: Squasher
        public async Task<IActionResult> Index()
        {
            return View(await _context.Squashers.ToListAsync());
        }

        // GET: Squasher/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var squasherModel = await _context.Squashers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (squasherModel == null)
            {
                return NotFound();
            }

            return View(squasherModel);
        }

        // GET: Squasher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Squasher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] SquasherModel squasherModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(squasherModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(squasherModel);
        }

        // GET: Squasher/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var squasherModel = await _context.Squashers.FindAsync(id);
            if (squasherModel == null)
            {
                return NotFound();
            }
            return View(squasherModel);
        }

        // POST: Squasher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] SquasherModel squasherModel)
        {
            if (id != squasherModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(squasherModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SquasherModelExists(squasherModel.ID))
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
            return View(squasherModel);
        }

        // GET: Squasher/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var squasherModel = await _context.Squashers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (squasherModel == null)
            {
                return NotFound();
            }

            return View(squasherModel);
        }

        // POST: Squasher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var squasherModel = await _context.Squashers.FindAsync(id);
            _context.Squashers.Remove(squasherModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SquasherModelExists(int id)
        {
            return _context.Squashers.Any(e => e.ID == id);
        }
    }
}
