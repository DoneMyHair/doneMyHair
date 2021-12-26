using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HairDresser1.Data;
using HairDresser1.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace HairDresser1.Controllers
{
    public class SaloonController : Controller
    {
        private readonly HairDresserDbContext _context;

        public SaloonController(HairDresserDbContext context)
        {
            _context = context;
        }

        // GET: Saloon
        public async Task<IActionResult> Index()
        {
            return View(await _context.Saloon.ToListAsync());
        }

        public async Task<SaloonModel> GetSaloonbyID (string id)
        {
            return await _context.Saloon.Where(m => m.ID == id).Select(x => new SaloonModel()
            {
                ID = x.ID,
                Description = x.Description,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                SaloonAdress = x.SaloonAdress,
                SaloonName = x.SaloonName,
                SaloonOwnerID = x.SaloonOwnerID
            }).FirstOrDefaultAsync();
            
        }
        public async Task<ApplicationUser> GetUserbyID (string id)
        {
            return await _context.ApplicationUser.Where(m => m.ID == id).FirstOrDefaultAsync();
        }
        // GET: Saloon/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Saloon = await _context.Saloon.Where(m => m.ID == id).FirstOrDefaultAsync();
            ViewBag.dressers = await _context.HairDresser.Where(x => x.SaloonID == Saloon.ID).ToListAsync();
            if (Saloon == null)
            {
                return NotFound();
            }

            return View(Saloon);
        }

        // GET: Saloon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Saloon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaloonModel model)
        {
            if (ModelState.IsValid)
            {
                var saloon = new Saloon()
                {
                    Description = model.Description,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    SaloonAdress = model.SaloonAdress,
                    SaloonName = model.SaloonName,
                    SaloonOwnerID = TempData["ownerid"].ToString(),
                    SaloonOwnerName = GetUserbyID(TempData["ownerid"].ToString()).Result.Name + " " + GetUserbyID(TempData["ownerid"].ToString()).Result.Surname
                };
                string filePath = System.IO.Path.GetTempFileName();
                if (model.Image != null)
                {
                    using var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create);
                    await model.Image.CopyToAsync(stream, System.Threading.CancellationToken.None);
                }
                saloon.Images = System.IO.File.ReadAllBytes(filePath);
                saloon.ID = Guid.NewGuid().ToString();
                _context.Add(saloon);
                await _context.SaveChangesAsync();
                ViewBag.dressers = new List<HairDresser>();
                return RedirectToAction("Details", new { id = saloon.ID });
            }
            return View(model);
        }

        // GET: Saloon/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
        
            var Saloon = await _context.Saloon.Where(z => z.ID == id).Select(x => new SaloonModel()
            {
                ID = x.ID,
                Description = x.Description,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                SaloonName = x.SaloonName,
                SaloonAdress = x.SaloonAdress,
                SaloonOwnerID = x.SaloonOwnerID,
                SaloonOwnerName = x.SaloonOwnerName
            }).FirstOrDefaultAsync();
            if (Saloon == null)
            {
                return NotFound();
            }
            return View(Saloon);
        }

        // POST: Saloon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, SaloonModel model)
        {
            Saloon saloon;
            if (id != model.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    saloon = new Saloon()
                    {
                        ID = model.ID,
                        Description = model.Description,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        SaloonName = model.SaloonName,
                        SaloonAdress = model.SaloonAdress,
                        SaloonOwnerID = model.SaloonOwnerID,
                        SaloonOwnerName = model.SaloonOwnerName
                    };
                    string filePath = System.IO.Path.GetTempFileName();
                    if (model.Image != null)
                    {
                        using var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Create);
                        await model.Image.CopyToAsync(stream, System.Threading.CancellationToken.None);
                    }

                    saloon.Images = System.IO.File.ReadAllBytes(filePath);
                    
                    _context.Saloon.Update(saloon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaloonExists(model.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details",new {id = saloon.ID });
            }
            return View(model);
        }

        // GET: Saloon/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Saloon = await _context.Saloon
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Saloon == null)
            {
                return NotFound();
            }

            return View(Saloon);
        }

        // POST: Saloon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var Saloon = await _context.Saloon.FindAsync(id);
            _context.Saloon.Remove(Saloon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaloonExists(string id)
        {
            return _context.Saloon.Any(e => e.ID == id);
        }
    }
}
