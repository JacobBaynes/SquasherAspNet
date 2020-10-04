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
    public class BugController : Controller
    {
        private readonly SquasherDbContext _context;

        public BugController(SquasherDbContext context)
        {
            _context = context;
        }

        // GET: Bug
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bugs.ToListAsync());
        }

        // GET: Bug/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugModel = await _context.Bugs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bugModel == null)
            {
                return NotFound();
            }

            return View(bugModel);
        }

        // GET: Bug/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bug/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,Severity,Version,TrackDate")] BugModel bugModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bugModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bugModel);
        }

        // GET: Bug/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugModel = await _context.Bugs.FindAsync(id);
            if (bugModel == null)
            {
                return NotFound();
            }
            return View(bugModel);
        }

        // POST: Bug/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,Severity,Version,TrackDate")] BugModel bugModel)
        {
            if (id != bugModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bugModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BugModelExists(bugModel.ID))
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
            return View(bugModel);
        }

        // GET: Bug/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bugModel = await _context.Bugs
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bugModel == null)
            {
                return NotFound();
            }

            return View(bugModel);
        }

        // POST: Bug/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bugModel = await _context.Bugs.FindAsync(id);
            _context.Bugs.Remove(bugModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BugModelExists(int id)
        {
            return _context.Bugs.Any(e => e.ID == id);
        }
    }
}
