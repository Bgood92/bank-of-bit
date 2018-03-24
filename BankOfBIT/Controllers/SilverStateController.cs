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
    public class SilverStateController : Controller
    {
        //Modified db.AccountStates.Add(silverstate) in the Create method to read db.SilverStates.Add(silverstate)

        private BankOfBITContext db = new BankOfBITContext();

        //
        // GET: /SilverState/
        // Modified the following code to return the GetInstance() method

        public ActionResult Index()
        {
            return View(SilverState.GetInstance());
        }

        //
        // GET: /SilverState/Details/5

        public ActionResult Details(int id = 0)
        {
            //Casted AccountStates to SilverState
            SilverState silverstate = (SilverState)db.AccountStates.Find(id);
            if (silverstate == null)
            {
                return HttpNotFound();
            }
            return View(silverstate);
        }

        //
        // GET: /SilverState/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SilverState/Create

        [HttpPost]
        public ActionResult Create(SilverState silverstate)
        {
            if (ModelState.IsValid)
            {
                db.SilverStates.Add(silverstate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(silverstate);
        }

        //
        // GET: /SilverState/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Casted AccountStates to SilverState
            SilverState silverstate = (SilverState)db.AccountStates.Find(id);
            if (silverstate == null)
            {
                return HttpNotFound();
            }
            return View(silverstate);
        }

        //
        // POST: /SilverState/Edit/5

        [HttpPost]
        public ActionResult Edit(SilverState silverstate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(silverstate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(silverstate);
        }

        //
        // GET: /SilverState/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //Casted AccountStates to SilverState
            SilverState silverstate = (SilverState)db.AccountStates.Find(id);
            if (silverstate == null)
            {
                return HttpNotFound();
            }
            return View(silverstate);
        }

        //
        // POST: /SilverState/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //Casted AccountStates to SilverState
            SilverState silverstate = (SilverState)db.AccountStates.Find(id);
            db.AccountStates.Remove(silverstate);
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