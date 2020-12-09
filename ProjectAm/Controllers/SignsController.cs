using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectAm.Data;
using ProjectAm.Models;

namespace ProjectAm.Controllers
{
    public class SignsController : Controller
    {
        private readonly SignContext _context;

        public SignsController(SignContext context)
        {
            _context = context;
        }

        // GET: Signs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Signs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sign = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sign == null)
            {
                return NotFound();
            }

            return View(sign);
        }

        // GET: Signs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Signs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Login,Password,Email,Phone")] Sign sign)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sign);
        }

        // GET: Signs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sign = await _context.Users.FindAsync(id);
            if (sign == null)
            {
                return NotFound();
            }
            return View(sign);
        }

        // POST: Signs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Login,Password,Email,Phone")] Sign sign)
        {
            if (id != sign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignExists(sign.Id))
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
            return View(sign);
        }

        // GET: Signs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sign = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sign == null)
            {
                return NotFound();
            }

            return View(sign);
        }

        // POST: Signs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sign = await _context.Users.FindAsync(id);
            _context.Users.Remove(sign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
