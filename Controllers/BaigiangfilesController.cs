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
    public class BaigiangfilesController : Controller
    {
        private readonly qltt_CTNContext _context = new qltt_CTNContext();

        // GET: Baigiangfiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Baigiangfile.ToListAsync());
        }

        // GET: Baigiangfiles/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baigiangfile = await _context.Baigiangfile
                .FirstOrDefaultAsync(m => m.BgfId == id);
            if (baigiangfile == null)
            {
                return NotFound();
            }

            return View(baigiangfile);
        }

        // GET: Baigiangfiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Baigiangfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BgfId,BgfTen,BgfFile")] Baigiangfile baigiangfile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baigiangfile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baigiangfile);
        }

        // GET: Baigiangfiles/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baigiangfile = await _context.Baigiangfile.FindAsync(id);
            if (baigiangfile == null)
            {
                return NotFound();
            }
            return View(baigiangfile);
        }

        // POST: Baigiangfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BgfId,BgfTen,BgfFile")] Baigiangfile baigiangfile)
        {
            if (id != baigiangfile.BgfId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baigiangfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaigiangfileExists(baigiangfile.BgfId))
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
            return View(baigiangfile);
        }

        // GET: Baigiangfiles/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baigiangfile = await _context.Baigiangfile
                .FirstOrDefaultAsync(m => m.BgfId == id);
            if (baigiangfile == null)
            {
                return NotFound();
            }

            return View(baigiangfile);
        }

        // POST: Baigiangfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var baigiangfile = await _context.Baigiangfile.FindAsync(id);
            _context.Baigiangfile.Remove(baigiangfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaigiangfileExists(string id)
        {
            return _context.Baigiangfile.Any(e => e.BgfId == id);
        }
    }
}
