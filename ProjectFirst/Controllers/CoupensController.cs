using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectFirst.Data;
using ProjectFirst.Models;

namespace ProjectFirst.Controllers
{
    public class CoupensController : Controller
    {
        private readonly FirstContext _context;

        public CoupensController(FirstContext context)
        {
            _context = context;
        }

        // GET: Coupens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coupen.ToListAsync());
        }

        // GET: Coupens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupen = await _context.Coupen
                .FirstOrDefaultAsync(m => m.CoupenID == id);
            if (coupen == null)
            {
                return NotFound();
            }

            return View(coupen);
        }

        // GET: Coupens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coupens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<IActionResult> Create([Bind("CoupenID,CoupenName,Amount,CoupenCode")] Coupen coupen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coupen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coupen);
        }

        // GET: Coupens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupen = await _context.Coupen.FindAsync(id);
            if (coupen == null)
            {
                return NotFound();
            }
            return View(coupen);
        }

        // POST: Coupens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoupenID,CoupenName,Amount,CoupenCode")] Coupen coupen)
        {
            if (id != coupen.CoupenID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coupen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoupenExists(coupen.CoupenID))
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
            return View(coupen);
        }

        // GET: Coupens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupen = await _context.Coupen
                .FirstOrDefaultAsync(m => m.CoupenID == id);
            if (coupen == null)
            {
                return NotFound();
            }

            return View(coupen);
        }

        // POST: Coupens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coupen = await _context.Coupen.FindAsync(id);
            _context.Coupen.Remove(coupen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoupenExists(int id)
        {
            return _context.Coupen.Any(e => e.CoupenID == id);
        }
    }
}
