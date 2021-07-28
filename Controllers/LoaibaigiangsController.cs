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
    public class LoaibaigiangsController : Controller
    {
        private readonly qltt_CTNContext _context = new qltt_CTNContext();

        // GET: Loaibaigiangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Loaibaigiang.ToListAsync());
        }

        // GET: Loaibaigiangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaibaigiang = await _context.Loaibaigiang
                .FirstOrDefaultAsync(m => m.LoaiId == id);
            if (loaibaigiang == null)
            {
                return NotFound();
            }

            return View(loaibaigiang);
        }

        // GET: Loaibaigiangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loaibaigiangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoaiId,LoaiTen")] Loaibaigiang loaibaigiang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaibaigiang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaibaigiang);
        }

        // GET: Loaibaigiangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaibaigiang = await _context.Loaibaigiang.FindAsync(id);
            if (loaibaigiang == null)
            {
                return NotFound();
            }
            return View(loaibaigiang);
        }

        // POST: Loaibaigiangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("LoaiId,LoaiTen")] Loaibaigiang loaibaigiang)
        {
            if (id != loaibaigiang.LoaiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaibaigiang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaibaigiangExists(loaibaigiang.LoaiId))
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
            return View(loaibaigiang);
        }

        // GET: Loaibaigiangs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaibaigiang = await _context.Loaibaigiang
                .FirstOrDefaultAsync(m => m.LoaiId == id);
            if (loaibaigiang == null)
            {
                return NotFound();
            }

            return View(loaibaigiang);
        }

        // POST: Loaibaigiangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var loaibaigiang = await _context.Loaibaigiang.FindAsync(id);
            _context.Loaibaigiang.Remove(loaibaigiang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaibaigiangExists(string id)
        {
            return _context.Loaibaigiang.Any(e => e.LoaiId == id);
        }
    }
}
