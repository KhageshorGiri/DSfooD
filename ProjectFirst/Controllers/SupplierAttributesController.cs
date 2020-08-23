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
    public class SupplierAttributesController : Controller
    {
        private readonly FirstContext _context;

        public SupplierAttributesController(FirstContext context)
        {
            _context = context;
        }

        // GET: SupplierAttributes
        public async Task<IActionResult> Index()
        {
            var firstContext = _context.SupplierAttribute.Include(s => s.Suppiler);
            return View(await firstContext.ToListAsync());
        }

        // GET: SupplierAttributes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierAttribute = await _context.SupplierAttribute
                .Include(s => s.Suppiler)
                .FirstOrDefaultAsync(m => m.suppilerAttributeID == id);
            if (supplierAttribute == null)
            {
                return NotFound();
            }

            return View(supplierAttribute);
        }

        // GET: SupplierAttributes/Create
        public IActionResult Create()
        {
            ViewData["SuppilerID"] = new SelectList(_context.Supplier, "SuppliersID", "SuppliersID");
            return View();
        }

        // POST: SupplierAttributes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Create([Bind("suppilerAttributeID,TotalAmount,PaidAmount,SuppilerID")] SupplierAttribute supplierAttribute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplierAttribute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SuppilerID"] = new SelectList(_context.Supplier, "SuppliersID", "SuppliersID", supplierAttribute.SuppilerID);
            return View(supplierAttribute);
        }

        // GET: SupplierAttributes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierAttribute = await _context.SupplierAttribute.FindAsync(id);
            if (supplierAttribute == null)
            {
                return NotFound();
            }
            ViewData["SuppilerID"] = new SelectList(_context.Supplier, "SuppliersID", "SuppliersID", supplierAttribute.SuppilerID);
            return View(supplierAttribute);
        }

        // POST: SupplierAttributes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("suppilerAttributeID,TotalAmount,PaidAmount,SuppilerID")] SupplierAttribute supplierAttribute)
        {
            if (id != supplierAttribute.suppilerAttributeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplierAttribute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierAttributeExists(supplierAttribute.suppilerAttributeID))
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
            ViewData["SuppilerID"] = new SelectList(_context.Supplier, "SuppliersID", "SuppliersID", supplierAttribute.SuppilerID);
            return View(supplierAttribute);
        }

        // GET: SupplierAttributes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplierAttribute = await _context.SupplierAttribute
                .Include(s => s.Suppiler)
                .FirstOrDefaultAsync(m => m.suppilerAttributeID == id);
            if (supplierAttribute == null)
            {
                return NotFound();
            }

            return View(supplierAttribute);
        }

        // POST: SupplierAttributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplierAttribute = await _context.SupplierAttribute.FindAsync(id);
            _context.SupplierAttribute.Remove(supplierAttribute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierAttributeExists(int id)
        {
            return _context.SupplierAttribute.Any(e => e.suppilerAttributeID == id);
        }
    }
}
