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
    public class BaigiangsController : Controller
    {
       private readonly qltt_CTNContext _context = new qltt_CTNContext();

        // GET: Baigiangs
        public async Task<IActionResult> Index()
        {
            var qltt_CTNContext = _context.Baigiang.Include(b => b.Bgf).Include(b => b.Loai);
            return View(await qltt_CTNContext.ToListAsync());
        }

        // GET: Baigiangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baigiang = await _context.Baigiang
                .Include(b => b.Bgf)
                .Include(b => b.Loai)
                .FirstOrDefaultAsync(m => m.BgId == id);
            if (baigiang == null)
            {
                return NotFound();
            }

            return View(baigiang);
        }

        // GET: Baigiangs/Create
        public IActionResult Create()
        {
            ViewData["BgfId"] = new SelectList(_context.Baigiangfile, "BgfId", "BgfId");
            ViewData["LoaiId"] = new SelectList(_context.Loaibaigiang, "LoaiId", "LoaiId");
            return View();
        }

        // POST: Baigiangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BgId,BgTen,BgTrangthai,LoaiId,BgfId")] Baigiang baigiang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baigiang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BgfId"] = new SelectList(_context.Baigiangfile, "BgfId", "BgfId", baigiang.BgfId);
            ViewData["LoaiId"] = new SelectList(_context.Loaibaigiang, "LoaiId", "LoaiId", baigiang.LoaiId);
            return View(baigiang);
        }

        // GET: Baigiangs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baigiang = await _context.Baigiang.FindAsync(id);
            if (baigiang == null)
            {
                return NotFound();
            }
            ViewData["BgfId"] = new SelectList(_context.Baigiangfile, "BgfId", "BgfId", baigiang.BgfId);
            ViewData["LoaiId"] = new SelectList(_context.Loaibaigiang, "LoaiId", "LoaiId", baigiang.LoaiId);
            return View(baigiang);
        }

        // POST: Baigiangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BgId,BgTen,BgTrangthai,LoaiId,BgfId")] Baigiang baigiang)
        {
            if (id != baigiang.BgId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baigiang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaigiangExists(baigiang.BgId))
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
            ViewData["BgfId"] = new SelectList(_context.Baigiangfile, "BgfId", "BgfId", baigiang.BgfId);
            ViewData["LoaiId"] = new SelectList(_context.Loaibaigiang, "LoaiId", "LoaiId", baigiang.LoaiId);
            return View(baigiang);
        }

        // GET: Baigiangs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baigiang = await _context.Baigiang
                .Include(b => b.Bgf)
                .Include(b => b.Loai)
                .FirstOrDefaultAsync(m => m.BgId == id);
            if (baigiang == null)
            {
                return NotFound();
            }

            return View(baigiang);
        }

        // POST: Baigiangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var baigiang = await _context.Baigiang.FindAsync(id);
            _context.Baigiang.Remove(baigiang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaigiangExists(string id)
        {
            return _context.Baigiang.Any(e => e.BgId == id);
        }
    }
}
