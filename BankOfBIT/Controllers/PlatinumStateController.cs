using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankOfBIT.Models;

namespace BankOfBIT.Controllers
{
    public class PlatinumStateController : Controller
    {
        //Modified db.AccountStates.Add(silverstate) in the Create method to read db.PlatinumStates.Add(silverstate)
        //Casted every instance of db.AccountStates.Find(id) to a PlatinumState

        private BankOfBITContext db = new BankOfBITContext();

        //
        // GET: /PlatinumState/
        // Modified the following code to return the GetInstance() method

        public ActionResult Index()
        {
            return View(PlatinumState.GetInstance());
        }

        //
        // GET: /PlatinumState/Details/5

        public ActionResult Details(int id = 0)
        {
            PlatinumState platinumstate = (PlatinumState)db.AccountStates.Find(id);
            if (platinumstate == null)
            {
                return HttpNotFound();
            }
            return View(platinumstate);
        }

        //
        // GET: /PlatinumState/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PlatinumState/Create

        [HttpPost]
        public ActionResult Create(PlatinumState platinumstate)
        {
            if (ModelState.IsValid)
            {
                db.PlatinumStates.Add(platinumstate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(platinumstate);
        }

        //
        // GET: /PlatinumState/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PlatinumState platinumstate = (PlatinumState)db.AccountStates.Find(id);
            if (platinumstate == null)
            {
                return HttpNotFound();
            }
            return View(platinumstate);
        }

        //
        // POST: /PlatinumState/Edit/5

        [HttpPost]
        public ActionResult Edit(PlatinumState platinumstate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(platinumstate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(platinumstate);
        }

        //
        // GET: /PlatinumState/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PlatinumState platinumstate = (PlatinumState)db.AccountStates.Find(id);
            if (platinumstate == null)
            {
                return HttpNotFound();
            }
            return View(platinumstate);
        }

        //
        // POST: /PlatinumState/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PlatinumState platinumstate = (PlatinumState)db.AccountStates.Find(id);
            db.AccountStates.Remove(platinumstate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}