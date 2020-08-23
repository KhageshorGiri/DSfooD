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
    public class DeliverymenController : Controller
    {
        private readonly FirstContext _context;

        public DeliverymenController(FirstContext context)
        {
            _context = context;
        }

        // GET: Deliverymen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deliveryman.ToListAsync());
        }

        // GET: Deliverymen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryman = await _context.Deliveryman
                .FirstOrDefaultAsync(m => m.DeliverymansID == id);
            if (deliveryman == null)
            {
                return NotFound();
            }

            return View(deliveryman);
        }

        // GET: Deliverymen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deliverymen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
 
        public async Task<IActionResult> Create([Bind("DeliverymansID,DeliverymanName,Address,PhoneNo,CitizenshipNo")] Deliveryman deliveryman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryman);
        }

        // GET: Deliverymen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryman = await _context.Deliveryman.FindAsync(id);
            if (deliveryman == null)
            {
                return NotFound();
            }
            return View(deliveryman);
        }

        // POST: Deliverymen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeliverymansID,DeliverymanName,Address,PhoneNo,CitizenshipNo")] Deliveryman deliveryman)
        {
            if (id != deliveryman.DeliverymansID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliverymanExists(deliveryman.DeliverymansID))
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
            return View(deliveryman);
        }

        // GET: Deliverymen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryman = await _context.Deliveryman
                .FirstOrDefaultAsync(m => m.DeliverymansID == id);
            if (deliveryman == null)
            {
                return NotFound();
            }

            return View(deliveryman);
        }

        // POST: Deliverymen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryman = await _context.Deliveryman.FindAsync(id);
            _context.Deliveryman.Remove(deliveryman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliverymanExists(int id)
        {
            return _context.Deliveryman.Any(e => e.DeliverymansID == id);
        }
    }
}
