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
    public class HocviensController : Controller
    {
        private readonly qltt_CTNContext _context = new qltt_CTNContext();

        // GET: Hocviens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hocvien.ToListAsync());
        }

        // GET: Hocviens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocvien = await _context.Hocvien
                .FirstOrDefaultAsync(m => m.HvId == id);
            if (hocvien == null)
            {
                return NotFound();
            }

            return View(hocvien);
        }

        // GET: Hocviens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hocviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HvId,HvNgaysinh,HvGioitinh,HvDiachi,HvSdt,HvEmail,HvNgayvao,HvHinhanh")] Hocvien hocvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hocvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hocvien);
        }

        // GET: Hocviens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocvien = await _context.Hocvien.FindAsync(id);
            if (hocvien == null)
            {
                return NotFound();
            }
            return View(hocvien);
        }

        // POST: Hocviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("HvId,HvNgaysinh,HvGioitinh,HvDiachi,HvSdt,HvEmail,HvNgayvao,HvHinhanh")] Hocvien hocvien)
        {
            if (id != hocvien.HvId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hocvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HocvienExists(hocvien.HvId))
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
            return View(hocvien);
        }

        // GET: Hocviens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocvien = await _context.Hocvien
                .FirstOrDefaultAsync(m => m.HvId == id);
            if (hocvien == null)
            {
                return NotFound();
            }

            return View(hocvien);
        }

        // POST: Hocviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hocvien = await _context.Hocvien.FindAsync(id);
            _context.Hocvien.Remove(hocvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HocvienExists(string id)
        {
            return _context.Hocvien.Any(e => e.HvId == id);
        }
    }
}
