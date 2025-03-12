using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vehiculos.Data;
using Vehiculos.Models;

namespace Vehiculos.Controllers
{
    public class VehiculosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiculosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehiculos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehiculos.ToListAsync());
        }

        // GET: Vehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculosModels = await _context.Vehiculos
                .FirstOrDefaultAsync(m => m.VehiculoId == id);
            if (vehiculosModels == null)
            {
                return NotFound();
            }

            return View(vehiculosModels);
        }

        // GET: Vehiculos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehiculoId,Marca,Modelo,Año,Disponible")] VehiculosModels vehiculosModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehiculosModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculosModels);
        }

        // GET: Vehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculosModels = await _context.Vehiculos.FindAsync(id);
            if (vehiculosModels == null)
            {
                return NotFound();
            }
            return View(vehiculosModels);
        }

        // POST: Vehiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehiculoId,Marca,Modelo,Año,Disponible")] VehiculosModels vehiculosModels)
        {
            if (id != vehiculosModels.VehiculoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculosModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculosModelsExists(vehiculosModels.VehiculoId))
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
            return View(vehiculosModels);
        }

        // GET: Vehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculosModels = await _context.Vehiculos
                .FirstOrDefaultAsync(m => m.VehiculoId == id);
            if (vehiculosModels == null)
            {
                return NotFound();
            }

            return View(vehiculosModels);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculosModels = await _context.Vehiculos.FindAsync(id);
            if (vehiculosModels != null)
            {
                _context.Vehiculos.Remove(vehiculosModels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculosModelsExists(int id)
        {
            return _context.Vehiculos.Any(e => e.VehiculoId == id);
        }
    }
}
