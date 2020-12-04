using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcHelpDesk.Data;
using MvcHelpDesk.Models;

namespace MvcHelpDesk.Controllers
{
    public class DenunciarController : Controller
    {
        private readonly MvcHelpDeskContext _context;

        public DenunciarController(MvcHelpDeskContext context)
        {
            _context = context;
        }

        // GET: Denunciar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Denunciar.ToListAsync());
        }

        // GET: Denunciar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denunciar = await _context.Denunciar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (denunciar == null)
            {
                return NotFound();
            }

            return View(denunciar);
        }

        // GET: Denunciar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Denunciar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Usuario,Tecnico,Descricao")] Denunciar denunciar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(denunciar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(denunciar);
        }

        // GET: Denunciar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denunciar = await _context.Denunciar.FindAsync(id);
            if (denunciar == null)
            {
                return NotFound();
            }
            return View(denunciar);
        }

        // POST: Denunciar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Usuario,Tecnico,Descricao")] Denunciar denunciar)
        {
            if (id != denunciar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(denunciar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenunciarExists(denunciar.Id))
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
            return View(denunciar);
        }

        // GET: Denunciar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denunciar = await _context.Denunciar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (denunciar == null)
            {
                return NotFound();
            }

            return View(denunciar);
        }

        // POST: Denunciar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var denunciar = await _context.Denunciar.FindAsync(id);
            _context.Denunciar.Remove(denunciar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenunciarExists(int id)
        {
            return _context.Denunciar.Any(e => e.Id == id);
        }
    }
}
