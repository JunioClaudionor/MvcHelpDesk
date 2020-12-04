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
    public class OrdemDeServicoController : Controller
    {
        private readonly MvcHelpDeskContext _context;

        public OrdemDeServicoController(MvcHelpDeskContext context)
        {
            _context = context;
        }

        // GET: OrdemDeServico
        public async Task<IActionResult> Index(string searchString)
        {
            return View(await _context.OrdemDeServico.ToListAsync());
        }

        // GET: OrdemDeServico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemDeServico = await _context.OrdemDeServico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordemDeServico == null)
            {
                return NotFound();
            }

            return View(ordemDeServico);
        }

        // GET: OrdemDeServico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrdemDeServico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Endereco,TipoServico,CategoriaServico,DescricaoProblema,Status,DataSolicitacao")] OrdemDeServico ordemDeServico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordemDeServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordemDeServico);
        }

        // GET: OrdemDeServico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemDeServico = await _context.OrdemDeServico.FindAsync(id);
            if (ordemDeServico == null)
            {
                return NotFound();
            }
            return View(ordemDeServico);
        }

        // POST: OrdemDeServico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Endereco,TipoServico,CategoriaServico,DescricaoProblema,Status,DataSolicitacao")] OrdemDeServico ordemDeServico)
        {
            if (id != ordemDeServico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordemDeServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdemDeServicoExists(ordemDeServico.Id))
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
            return View(ordemDeServico);
        }

        // GET: OrdemDeServico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordemDeServico = await _context.OrdemDeServico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordemDeServico == null)
            {
                return NotFound();
            }

            return View(ordemDeServico);
        }

        // POST: OrdemDeServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordemDeServico = await _context.OrdemDeServico.FindAsync(id);
            _context.OrdemDeServico.Remove(ordemDeServico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdemDeServicoExists(int id)
        {
            return _context.OrdemDeServico.Any(e => e.Id == id);
        }
    }
}
