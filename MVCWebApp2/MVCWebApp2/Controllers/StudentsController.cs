using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using MVCWebApp2.Context;
using MVCWebApp2.Models;


namespace MVCWebApp2.Controllers
{
    public class StudentsController : Controller
    {

        private readonly DBRegistradosContext _context;

        public  StudentsController(DBRegistradosContext context)
        {

            _context = context;
        }


        // GET: StudentsController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.OrderByDescending(a=> a.ID).ToListAsync()); ;
        }

        // GET: StudentsController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Course)
                    .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id );


            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstMidName,LastName")] Student student)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    student.EnrollmentDate = DateTime.Now;

                    _context.Add(student);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));

                }

            }
            catch (DbUpdateException ex )
            {

                ModelState.AddModelError("Error",ex.Message);
            }


            return View(student);

        }

        // GET: StudentsController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
               .Include(s => s.Enrollments)
                   .ThenInclude(e => e.Course)
                   .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (student == null)
            {
                return NotFound();
            }


            return View(student);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  [Bind("ID, FirstMidName,LastName")] Student student)
        {
            try
            {

                if (id != student.ID)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {

                    student.EnrollmentDate = DateTime.Now;

                    _context.Update(student);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));

                }

            }
            catch (DbUpdateException ex)
            {

                ModelState.AddModelError("Error", ex.Message);
            }

            return View(student);

        }

        // GET: StudentsController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
               .Include(s => s.Enrollments)
                   .ThenInclude(e => e.Course)
                   .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: StudentsController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteData(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);

                if (student == null)
                {

                    return RedirectToAction(nameof(Index));
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));

            }
            catch (DbUpdateException ex)
            {

                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }

        }
    }
}
