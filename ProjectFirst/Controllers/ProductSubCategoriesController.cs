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
    public class ProductSubCategoriesController : Controller
    {
        private readonly FirstContext _context;

        public ProductSubCategoriesController(FirstContext context)
        {
            _context = context;
        }

        // GET: ProductSubCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductSubCategory.ToListAsync());
        }

        // GET: ProductSubCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSubCategory = await _context.ProductSubCategory
                .FirstOrDefaultAsync(m => m.ProductSubCategoryID == id);
            if (productSubCategory == null)
            {
                return NotFound();
            }

            return View(productSubCategory);
        }

        // GET: ProductSubCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductSubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductSubCategoryID,ProductSubCategoryName,Rate,Available,DisplayOrder,Image")] ProductSubCategory productSubCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productSubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productSubCategory);
        }

        // GET: ProductSubCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSubCategory = await _context.ProductSubCategory.FindAsync(id);
            if (productSubCategory == null)
            {
                return NotFound();
            }
            return View(productSubCategory);
        }

        // POST: ProductSubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductSubCategoryID,ProductSubCategoryName,Rate,Available,DisplayOrder,Image")] ProductSubCategory productSubCategory)
        {
            if (id != productSubCategory.ProductSubCategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productSubCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSubCategoryExists(productSubCategory.ProductSubCategoryID))
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
            return View(productSubCategory);
        }

        // GET: ProductSubCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSubCategory = await _context.ProductSubCategory
                .FirstOrDefaultAsync(m => m.ProductSubCategoryID == id);
            if (productSubCategory == null)
            {
                return NotFound();
            }

            return View(productSubCategory);
        }

        // POST: ProductSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productSubCategory = await _context.ProductSubCategory.FindAsync(id);
            _context.ProductSubCategory.Remove(productSubCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductSubCategoryExists(int id)
        {
            return _context.ProductSubCategory.Any(e => e.ProductSubCategoryID == id);
        }
    }
}
