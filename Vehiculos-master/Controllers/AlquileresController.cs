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
    public class AlquileresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlquileresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alquileres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Alquileres.Include(a => a.Cliente).Include(a => a.Vehiculo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Alquileres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquileresModels = await _context.Alquileres
                .Include(a => a.Cliente)
                .Include(a => a.Vehiculo)
                .FirstOrDefaultAsync(m => m.AlquilerId == id);
            if (alquileresModels == null)
            {
                return NotFound();
            }

            return View(alquileresModels);
        }

        // GET: Alquileres/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Apellido");
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "VehiculoId", "Marca");
            return View();
        }

        // POST: Alquileres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlquilerId,FechaInicio,FechaFin,VehiculoId,ClienteId")] AlquileresModels alquileresModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alquileresModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Apellido", alquileresModels.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "VehiculoId", "Marca", alquileresModels.VehiculoId);
            return View(alquileresModels);
        }

        // GET: Alquileres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquileresModels = await _context.Alquileres.FindAsync(id);
            if (alquileresModels == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Apellido", alquileresModels.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "VehiculoId", "Marca", alquileresModels.VehiculoId);
            return View(alquileresModels);
        }

        // POST: Alquileres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlquilerId,FechaInicio,FechaFin,VehiculoId,ClienteId")] AlquileresModels alquileresModels)
        {
            if (id != alquileresModels.AlquilerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alquileresModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlquileresModelsExists(alquileresModels.AlquilerId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Apellido", alquileresModels.ClienteId);
            ViewData["VehiculoId"] = new SelectList(_context.Vehiculos, "VehiculoId", "Marca", alquileresModels.VehiculoId);
            return View(alquileresModels);
        }

        // GET: Alquileres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquileresModels = await _context.Alquileres
                .Include(a => a.Cliente)
                .Include(a => a.Vehiculo)
                .FirstOrDefaultAsync(m => m.AlquilerId == id);
            if (alquileresModels == null)
            {
                return NotFound();
            }

            return View(alquileresModels);
        }

        // POST: Alquileres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alquileresModels = await _context.Alquileres.FindAsync(id);
            if (alquileresModels != null)
            {
                _context.Alquileres.Remove(alquileresModels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlquileresModelsExists(int id)
        {
            return _context.Alquileres.Any(e => e.AlquilerId == id);
        }
    }
}
