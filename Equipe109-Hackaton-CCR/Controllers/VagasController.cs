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
    public class VagasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VagasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vagas
        public async Task<IActionResult> Index()
        {
            return View(await _context.VagasModel.ToListAsync());
        }

        // GET: Vagas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagasModel = await _context.VagasModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vagasModel == null)
            {
                return NotFound();
            }

            return View(vagasModel);
        }

        // GET: Vagas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vagas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VagasModel vagasModel)
        {
            vagasModel.Id = Guid.NewGuid();

            vagasModel.EmpresaModel = Guid.Parse("7189a54d-c169-4f2e-975f-9acd2f772a99");
            _context.Add(vagasModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            return View(vagasModel);
        }

        // GET: Vagas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagasModel = await _context.VagasModel.FindAsync(id);
            if (vagasModel == null)
            {
                return NotFound();
            }
            return View(vagasModel);
        }

        // POST: Vagas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Titulo,Descricao,DataExpiracao,DataCriacao")] VagasModel vagasModel)
        {
            if (id != vagasModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vagasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagasModelExists(vagasModel.Id))
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
            return View(vagasModel);
        }

        // GET: Vagas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagasModel = await _context.VagasModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vagasModel == null)
            {
                return NotFound();
            }

            return View(vagasModel);
        }

        // POST: Vagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vagasModel = await _context.VagasModel.FindAsync(id);
            _context.VagasModel.Remove(vagasModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VagasModelExists(Guid id)
        {
            return _context.VagasModel.Any(e => e.Id == id);
        }
    }
}
