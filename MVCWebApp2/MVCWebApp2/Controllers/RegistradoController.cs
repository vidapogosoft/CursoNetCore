using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWebApp2.Context;
using MVCWebApp2.Models;

namespace MVCWebApp2.Controllers
{
    public class RegistradoController : Controller
    {
        private readonly DBRegistradosContext _context;

        public RegistradoController(DBRegistradosContext context)
        {
            _context = context;
        }

        // GET: Registrado
        public async Task<IActionResult> Index()
        {
            return View(await _context.Registrados.ToListAsync());
        }

        // GET: Registrado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrado = await _context.Registrados
                .FirstOrDefaultAsync(m => m.IdRegistrado == id);
            if (registrado == null)
            {
                return NotFound();
            }

            return View(registrado);
        }

        // GET: Registrado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registrado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegistrado,Identificacion,Nombres,Apellidos,NombresCompletos")] Registrado registrado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registrado);
        }

        // GET: Registrado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrado = await _context.Registrados.FindAsync(id);
            if (registrado == null)
            {
                return NotFound();
            }
            return View(registrado);
        }

        // POST: Registrado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegistrado,Identificacion,Nombres,Apellidos,NombresCompletos")] Registrado registrado)
        {
            if (id != registrado.IdRegistrado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistradoExists(registrado.IdRegistrado))
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
            return View(registrado);
        }

        // GET: Registrado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrado = await _context.Registrados
                .FirstOrDefaultAsync(m => m.IdRegistrado == id);
            if (registrado == null)
            {
                return NotFound();
            }

            return View(registrado);
        }

        // POST: Registrado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registrado = await _context.Registrados.FindAsync(id);
            _context.Registrados.Remove(registrado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistradoExists(int id)
        {
            return _context.Registrados.Any(e => e.IdRegistrado == id);
        }
    }
}
