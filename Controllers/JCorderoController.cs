using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JCExamenP1.Data;
using JCExamenP1.Models;

namespace JCExamenP1.Controllers
{
    public class JCorderoController : Controller
    {
        private readonly JCExamenP1Context _context;

        public JCorderoController(JCExamenP1Context context)
        {
            _context = context;
        }

        // GET: JCorderoes
        public async Task<IActionResult> Index()
        {
              return _context.JCordero != null ? 
                          View(await _context.JCordero.ToListAsync()) :
                          Problem("Entity set 'JCExamenP1Context.JCordero'  is null.");
        }

        // GET: JCorderoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JCordero == null)
            {
                return NotFound();
            }

            var jCordero = await _context.JCordero
                .FirstOrDefaultAsync(m => m.JCId == id);
            if (jCordero == null)
            {
                return NotFound();
            }

            return View(jCordero);
        }

        // GET: JCorderoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JCorderoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JCId,JCModelo,JCPrecio,JCRemanofacturado,FechaFabriacion")] JCordero jCordero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jCordero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jCordero);
        }

        // GET: JCorderoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JCordero == null)
            {
                return NotFound();
            }

            var jCordero = await _context.JCordero.FindAsync(id);
            if (jCordero == null)
            {
                return NotFound();
            }
            return View(jCordero);
        }

        // POST: JCorderoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JCId,JCModelo,JCPrecio,JCRemanofacturado,FechaFabriacion")] JCordero jCordero)
        {
            if (id != jCordero.JCId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jCordero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JCorderoExists(jCordero.JCId))
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
            return View(jCordero);
        }

        // GET: JCorderoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JCordero == null)
            {
                return NotFound();
            }

            var jCordero = await _context.JCordero
                .FirstOrDefaultAsync(m => m.JCId == id);
            if (jCordero == null)
            {
                return NotFound();
            }

            return View(jCordero);
        }

        // POST: JCorderoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JCordero == null)
            {
                return Problem("Entity set 'JCExamenP1Context.JCordero'  is null.");
            }
            var jCordero = await _context.JCordero.FindAsync(id);
            if (jCordero != null)
            {
                _context.JCordero.Remove(jCordero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JCorderoExists(int id)
        {
          return (_context.JCordero?.Any(e => e.JCId == id)).GetValueOrDefault();
        }
    }
}
