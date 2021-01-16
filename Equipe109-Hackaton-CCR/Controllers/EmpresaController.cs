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
    public class EmpresaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpresaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmpresaModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaModel = await _context.EmpresaModels
                .FirstOrDefaultAsync(m => m.IdEmpresa == id);
            if (empresaModel == null)
            {
                return NotFound();
            }

            return View(empresaModel);
        }

        // GET: EmpresaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpresaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpresa,Empresa,Ramo,QtdeFuncionarios,Estado,Cidade")] EmpresaModel empresaModel)
        {
            if (ModelState.IsValid)
            {
                empresaModel.IdEmpresa = Guid.NewGuid();
                _context.Add(empresaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresaModel);
        }

        // GET: EmpresaModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaModel = await _context.EmpresaModels.FindAsync(id);
            if (empresaModel == null)
            {
                return NotFound();
            }
            return View(empresaModel);
        }

        // POST: EmpresaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdEmpresa,Empresa,Ramo,QtdeFuncionarios,Estado,Cidade")] EmpresaModel empresaModel)
        {
            if (id != empresaModel.IdEmpresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaModelExists(empresaModel.IdEmpresa))
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
            return View(empresaModel);
        }

        // GET: EmpresaModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresaModel = await _context.EmpresaModels
                .FirstOrDefaultAsync(m => m.IdEmpresa == id);
            if (empresaModel == null)
            {
                return NotFound();
            }

            return View(empresaModel);
        }

        // POST: EmpresaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var empresaModel = await _context.EmpresaModels.FindAsync(id);
            _context.EmpresaModels.Remove(empresaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaModelExists(Guid id)
        {
            return _context.EmpresaModels.Any(e => e.IdEmpresa == id);
        }
    }
}
