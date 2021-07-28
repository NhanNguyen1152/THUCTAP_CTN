using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using thuctap_CTN.Models;

namespace thuctap_CTN.Controllers
{
    public class ChitietlopsController : Controller
    {
        private readonly qltt_CTNContext _context = new qltt_CTNContext();

        // GET: Chitietlops
        public async Task<IActionResult> Index()
        {
            var qltt_CTNContext = _context.Chitietlop.Include(c => c.Hv).Include(c => c.L);
            return View(await qltt_CTNContext.ToListAsync());
        }

        // GET: Chitietlops/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietlop = await _context.Chitietlop
                .Include(c => c.Hv)
                .Include(c => c.L)
                .FirstOrDefaultAsync(m => m.CtlId == id);
            if (chitietlop == null)
            {
                return NotFound();
            }

            return View(chitietlop);
        }

        // GET: Chitietlops/Create
        public IActionResult Create()
        {
            ViewData["HvId"] = new SelectList(_context.Hocvien, "HvId", "HvId");
            ViewData["LId"] = new SelectList(_context.Lop, "LId", "LId");
            return View();
        }

        // POST: Chitietlops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CtlId,HvId,LId")] Chitietlop chitietlop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chitietlop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HvId"] = new SelectList(_context.Hocvien, "HvId", "HvId", chitietlop.HvId);
            ViewData["LId"] = new SelectList(_context.Lop, "LId", "LId", chitietlop.LId);
            return View(chitietlop);
        }

        // GET: Chitietlops/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietlop = await _context.Chitietlop.FindAsync(id);
            if (chitietlop == null)
            {
                return NotFound();
            }
            ViewData["HvId"] = new SelectList(_context.Hocvien, "HvId", "HvId", chitietlop.HvId);
            ViewData["LId"] = new SelectList(_context.Lop, "LId", "LId", chitietlop.LId);
            return View(chitietlop);
        }

        // POST: Chitietlops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CtlId,HvId,LId")] Chitietlop chitietlop)
        {
            if (id != chitietlop.CtlId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chitietlop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitietlopExists(chitietlop.CtlId))
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
            ViewData["HvId"] = new SelectList(_context.Hocvien, "HvId", "HvId", chitietlop.HvId);
            ViewData["LId"] = new SelectList(_context.Lop, "LId", "LId", chitietlop.LId);
            return View(chitietlop);
        }

        // GET: Chitietlops/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietlop = await _context.Chitietlop
                .Include(c => c.Hv)
                .Include(c => c.L)
                .FirstOrDefaultAsync(m => m.CtlId == id);
            if (chitietlop == null)
            {
                return NotFound();
            }

            return View(chitietlop);
        }

        // POST: Chitietlops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var chitietlop = await _context.Chitietlop.FindAsync(id);
            _context.Chitietlop.Remove(chitietlop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChitietlopExists(string id)
        {
            return _context.Chitietlop.Any(e => e.CtlId == id);
        }
    }
}
