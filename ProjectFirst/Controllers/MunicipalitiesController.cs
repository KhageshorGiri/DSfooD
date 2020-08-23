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
    public class MunicipalitiesController : Controller
    {
        private readonly FirstContext _context;

        public MunicipalitiesController(FirstContext context)
        {
            _context = context;
        }

        // GET: Municipalities
        public async Task<IActionResult> Index()
        {
            var firstContext = _context.Municipality.Include(m => m.District);
            return View(await firstContext.ToListAsync());
        }

        // GET: Municipalities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipality = await _context.Municipality
                .Include(m => m.District)
                .FirstOrDefaultAsync(m => m.MunicipalityID == id);
            if (municipality == null)
            {
                return NotFound();
            }

            return View(municipality);
        }

        // GET: Municipalities/Create
        public IActionResult Create()
        {
            ViewData["DistrictID"] = new SelectList(_context.District, "DistrictID", "DistrictID");
            return View();
        }

        // POST: Municipalities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
   
        public async Task<IActionResult> Create([Bind("MunicipalityID,MunicipalityName,DistrictID")] Municipality municipality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(municipality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictID"] = new SelectList(_context.District, "DistrictID", "DistrictID", municipality.DistrictID);
            return View(municipality);
        }

        // GET: Municipalities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipality = await _context.Municipality.FindAsync(id);
            if (municipality == null)
            {
                return NotFound();
            }
            ViewData["DistrictID"] = new SelectList(_context.District, "DistrictID", "DistrictID", municipality.DistrictID);
            return View(municipality);
        }

        // POST: Municipalities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MunicipalityID,MunicipalityName,DistrictID")] Municipality municipality)
        {
            if (id != municipality.MunicipalityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(municipality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MunicipalityExists(municipality.MunicipalityID))
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
            ViewData["DistrictID"] = new SelectList(_context.District, "DistrictID", "DistrictID", municipality.DistrictID);
            return View(municipality);
        }

        // GET: Municipalities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipality = await _context.Municipality
                .Include(m => m.District)
                .FirstOrDefaultAsync(m => m.MunicipalityID == id);
            if (municipality == null)
            {
                return NotFound();
            }

            return View(municipality);
        }

        // POST: Municipalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var municipality = await _context.Municipality.FindAsync(id);
            _context.Municipality.Remove(municipality);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MunicipalityExists(int id)
        {
            return _context.Municipality.Any(e => e.MunicipalityID == id);
        }
    }
}
