using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Equipe109_Hackaton_CCR.Data;
using Equipe109_Hackaton_CCR.Models;

namespace Equipe109_Hackaton_CCR.Controllers
{
    public class VagasCandidatoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VagasCandidatoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VagasCandidato
        public async Task<IActionResult> Index()
        {
            return View(await _context.VagasCandidato.ToListAsync());
        }

        // GET: VagasCandidato/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagasCandidatoModel = await _context.VagasCandidato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vagasCandidatoModel == null)
            {
                return NotFound();
            }

            return View(vagasCandidatoModel);
        }

        // GET: VagasCandidato/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VagasCandidato/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VagasId,UserId")] VagasCandidatoModel vagasCandidatoModel)
        {
            if (ModelState.IsValid)
            {
                vagasCandidatoModel.Id = Guid.NewGuid();
                _context.Add(vagasCandidatoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vagasCandidatoModel);
        }

        // GET: VagasCandidato/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagasCandidatoModel = await _context.VagasCandidato.FindAsync(id);
            if (vagasCandidatoModel == null)
            {
                return NotFound();
            }
            return View(vagasCandidatoModel);
        }

        // POST: VagasCandidato/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,VagasId,UserId")] VagasCandidatoModel vagasCandidatoModel)
        {
            if (id != vagasCandidatoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vagasCandidatoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagasCandidatoModelExists(vagasCandidatoModel.Id))
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
            return View(vagasCandidatoModel);
        }

        // GET: VagasCandidato/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagasCandidatoModel = await _context.VagasCandidato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vagasCandidatoModel == null)
            {
                return NotFound();
            }

            return View(vagasCandidatoModel);
        }

        // POST: VagasCandidato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vagasCandidatoModel = await _context.VagasCandidato.FindAsync(id);
            _context.VagasCandidato.Remove(vagasCandidatoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VagasCandidatoModelExists(Guid id)
        {
            return _context.VagasCandidato.Any(e => e.Id == id);
        }
    }
}
