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
    public class GoldStateController : Controller
    {
        //Modified db.AccountStates.Add(silverstate) in the Create method to read db.GoldStates.Add(silverstate)

        private BankOfBITContext db = new BankOfBITContext();

        //
        // GET: /GoldState/
        // Modified the following code to return the GetInstance() method

        public ActionResult Index()
        {
            return View(GoldState.GetInstance());
        }

        //
        // GET: /GoldState/Details/5

        public ActionResult Details(int id = 0)
        {
            //Casted AccountState to a GoldState
            GoldState goldstate = (GoldState)db.AccountStates.Find(id);
            if (goldstate == null)
            {
                return HttpNotFound();
            }
            return View(goldstate);
        }

        //
        // GET: /GoldState/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /GoldState/Create

        [HttpPost]
        public ActionResult Create(GoldState goldstate)
        {
            if (ModelState.IsValid)
            {
                db.GoldStates.Add(goldstate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(goldstate);
        }

        //
        // GET: /GoldState/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Casted AccountState to a GoldState
            GoldState goldstate = (GoldState)db.AccountStates.Find(id);
            if (goldstate == null)
            {
                return HttpNotFound();
            }
            return View(goldstate);
        }

        //
        // POST: /GoldState/Edit/5

        [HttpPost]
        public ActionResult Edit(GoldState goldstate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(goldstate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(goldstate);
        }

        //
        // GET: /GoldState/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //Casted AccountState to a GoldState
            GoldState goldstate = (GoldState)db.AccountStates.Find(id);
            if (goldstate == null)
            {
                return HttpNotFound();
            }
            return View(goldstate);
        }

        //
        // POST: /GoldState/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //Casted AccountState to a GoldState
            GoldState goldstate = (GoldState)db.AccountStates.Find(id);
            db.AccountStates.Remove(goldstate);
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