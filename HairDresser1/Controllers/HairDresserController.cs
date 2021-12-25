using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HairDresser1.Data;
using HairDresser1.Models;

namespace HairDresser1.Controllers
{
    public class HairDresserController : Controller
    {
        private readonly HairDresserDbContext _context;

        public HairDresserController(HairDresserDbContext context)
        {
            _context = context;
        }

        // GET: HairDresser
        public async Task<IActionResult> Index()
        {
            return View(await _context.HairDresser.ToListAsync());
        }

        // GET: HairDresser/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hairDresserModel = await _context.HairDresser
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hairDresserModel == null)
            {
                return NotFound();
            }

            return View(hairDresserModel);
        }

        // GET: HairDresser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HairDresser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HairDresserModel model)
        {
            if (ModelState.IsValid)
            {
                var hairDresserModel = new HairDresser()
                {
                    
                    HairdresserDescription = model.HairdresserDescription,
                    HairdresserEmail = model.HairdresserEmail,
                    HairdresserName = model.HairdresserName,
                    HairdresserPhoneNumber = model.HairdresserPhoneNumber,
                    HairdresserSurname = model.HairdresserSurname
                };
                hairDresserModel.ID = Guid.NewGuid().ToString();
                hairDresserModel.SaloonID = TempData["SaloonID"].ToString();
                string filePath = System.IO.Path.GetTempFileName();
                if (model.Image != null)
                {
                    using var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create);
                    await model.Image.CopyToAsync(stream, System.Threading.CancellationToken.None);
                }
                hairDresserModel.Image = System.IO.File.ReadAllBytes(filePath);
                _context.HairDresser.Add(hairDresserModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details","Saloon", new { id = hairDresserModel.SaloonID });
            }
            return View(model);
        }

        // GET: HairDresser/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hairDresserModel = await _context.HairDresser.FindAsync(id);
            if (hairDresserModel == null)
            {
                return NotFound();
            }
            return View(hairDresserModel);
        }

        // POST: HairDresser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,SaloonID,HairdresserName,HairdresserSurname,HairdresserPhoneNumber,HairdresserEmail,HairdresserDescription")] HairDresserModel hairDresserModel)
        {
            if (id != hairDresserModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hairDresserModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HairDresserModelExists(hairDresserModel.ID))
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
            return View(hairDresserModel);
        }

        // GET: HairDresser/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hairDresserModel = await _context.HairDresser
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hairDresserModel == null)
            {
                return NotFound();
            }

            return View(hairDresserModel);
        }

        // POST: HairDresser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hairDresserModel = await _context.HairDresser.FindAsync(id);
            _context.HairDresser.Remove(hairDresserModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HairDresserModelExists(string id)
        {
            return _context.HairDresser.Any(e => e.ID == id);
        }
    }
}
