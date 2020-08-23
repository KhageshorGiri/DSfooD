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
    public class DeliveryInformationsController : Controller
    {
        private readonly FirstContext _context;

        public DeliveryInformationsController(FirstContext context)
        {
            _context = context;
        }

        // GET: DeliveryInformations
        public async Task<IActionResult> Index()
        {
            var firstContext = _context.DeliveryInformation.Include(d => d.Client);
            return View(await firstContext.ToListAsync());
        }

        // GET: DeliveryInformations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryInformation = await _context.DeliveryInformation
                .Include(d => d.Client)
                .FirstOrDefaultAsync(m => m.DeliveryInformationID == id);
            if (deliveryInformation == null)
            {
                return NotFound();
            }

            return View(deliveryInformation);
        }

        // GET: DeliveryInformations/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "ClientID");
            return View();
        }

        // POST: DeliveryInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Create([Bind("DeliveryInformationID,ClientID,DeliverymansID,Signature")] DeliveryInformation deliveryInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "ClientID", deliveryInformation.ClientID);
            return View(deliveryInformation);
        }

        // GET: DeliveryInformations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryInformation = await _context.DeliveryInformation.FindAsync(id);
            if (deliveryInformation == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "ClientID", deliveryInformation.ClientID);
            return View(deliveryInformation);
        }

        // POST: DeliveryInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeliveryInformationID,ClientID,DeliverymansID,Signature")] DeliveryInformation deliveryInformation)
        {
            if (id != deliveryInformation.DeliveryInformationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryInformationExists(deliveryInformation.DeliveryInformationID))
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
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "ClientID", deliveryInformation.ClientID);
            return View(deliveryInformation);
        }

        // GET: DeliveryInformations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryInformation = await _context.DeliveryInformation
                .Include(d => d.Client)
                .FirstOrDefaultAsync(m => m.DeliveryInformationID == id);
            if (deliveryInformation == null)
            {
                return NotFound();
            }

            return View(deliveryInformation);
        }

        // POST: DeliveryInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryInformation = await _context.DeliveryInformation.FindAsync(id);
            _context.DeliveryInformation.Remove(deliveryInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryInformationExists(int id)
        {
            return _context.DeliveryInformation.Any(e => e.DeliveryInformationID == id);
        }
    }
}
