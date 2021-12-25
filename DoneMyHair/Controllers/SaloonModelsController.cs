using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoneMyHair.Models;

namespace DoneMyHair.Controllers
{
    public class SaloonModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SaloonModels
        public async Task<ActionResult> Index()
        {
            return View(await db.SaloonModels.ToListAsync());
        }

        // GET: SaloonModels/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaloonModels saloonModels = await db.SaloonModels.FindAsync(id);
            if (saloonModels == null)
            {
                return HttpNotFound();
            }
            return View(saloonModels);
        }

        // GET: SaloonModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaloonModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,SaloonName,PhoneNumber,Email,Description,SaloonOwnerID,SaloonAdress,Images")] SaloonModels saloonModels)
        {
            saloonModels.SaloonOwnerID = TempData["ownerid"].ToString();

            if (ModelState.IsValid)
            {
                db.SaloonModels.Add(saloonModels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(saloonModels);
        }

        // GET: SaloonModels/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaloonModels saloonModels = await db.SaloonModels.FindAsync(id);
            if (saloonModels == null)
            {
                return HttpNotFound();
            }
            return View(saloonModels);
        }

        // POST: SaloonModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,SaloonName,PhoneNumber,Email,Description,SaloonOwnerID,SaloonAdress,Images")] SaloonModels saloonModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saloonModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(saloonModels);
        }

        // GET: SaloonModels/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaloonModels saloonModels = await db.SaloonModels.FindAsync(id);
            if (saloonModels == null)
            {
                return HttpNotFound();
            }
            return View(saloonModels);
        }

        // POST: SaloonModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            SaloonModels saloonModels = await db.SaloonModels.FindAsync(id);
            db.SaloonModels.Remove(saloonModels);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
