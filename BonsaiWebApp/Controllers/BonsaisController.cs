using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonsaiWebApp.Models;

namespace BonsaiWebApp.Controllers
{
    public class BonsaisController : Controller
    {
        private readonly AppDbContext _context;

        public BonsaisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Bonsais
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Bonsais.Include(b => b.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Bonsais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bonsai = await _context.Bonsais
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.BonsaiId == id);
            if (bonsai == null)
            {
                return NotFound();
            }

            return View(bonsai);
        }

        // GET: Bonsais/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Bonsais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BonsaiId,Code,Name,Description,CategoryId,CreateAt,UpdateAt,DeleteAt,IsDeleted")] Bonsai bonsai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bonsai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", bonsai.CategoryId);
            return View(bonsai);
        }

        // GET: Bonsais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bonsai = await _context.Bonsais.FindAsync(id);
            if (bonsai == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", bonsai.CategoryId);
            return View(bonsai);
        }

        // POST: Bonsais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BonsaiId,Code,Name,Description,CategoryId,CreateAt,UpdateAt,DeleteAt,IsDeleted")] Bonsai bonsai)
        {
            if (id != bonsai.BonsaiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bonsai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BonsaiExists(bonsai.BonsaiId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name", bonsai.CategoryId);
            return View(bonsai);
        }

        // GET: Bonsais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bonsai = await _context.Bonsais
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.BonsaiId == id);
            if (bonsai == null)
            {
                return NotFound();
            }

            return View(bonsai);
        }

        // POST: Bonsais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bonsai = await _context.Bonsais.FindAsync(id);
            _context.Bonsais.Remove(bonsai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BonsaiExists(int id)
        {
            return _context.Bonsais.Any(e => e.BonsaiId == id);
        }
    }
}
