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
    public class GifCardsController : Controller
    {
        private readonly FirstContext _context;

        public GifCardsController(FirstContext context)
        {
            _context = context;
        }

        // GET: GifCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.GifCard.ToListAsync());
        }

        // GET: GifCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gifCard = await _context.GifCard
                .FirstOrDefaultAsync(m => m.GifCardID == id);
            if (gifCard == null)
            {
                return NotFound();
            }

            return View(gifCard);
        }

        // GET: GifCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GifCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
     
        public async Task<IActionResult> Create([Bind("GifCardID,GifCardName,Amount,Code")] GifCard gifCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gifCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gifCard);
        }

        // GET: GifCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gifCard = await _context.GifCard.FindAsync(id);
            if (gifCard == null)
            {
                return NotFound();
            }
            return View(gifCard);
        }

        // POST: GifCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GifCardID,GifCardName,Amount,Code")] GifCard gifCard)
        {
            if (id != gifCard.GifCardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gifCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GifCardExists(gifCard.GifCardID))
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
            return View(gifCard);
        }

        // GET: GifCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gifCard = await _context.GifCard
                .FirstOrDefaultAsync(m => m.GifCardID == id);
            if (gifCard == null)
            {
                return NotFound();
            }

            return View(gifCard);
        }

        // POST: GifCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gifCard = await _context.GifCard.FindAsync(id);
            _context.GifCard.Remove(gifCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GifCardExists(int id)
        {
            return _context.GifCard.Any(e => e.GifCardID == id);
        }
    }
}
