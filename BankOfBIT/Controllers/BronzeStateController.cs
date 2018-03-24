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
    public class BronzeStateController : Controller
    {
        //Modified db.AccountStates.Add(silverstate) in the Create method to read db.BronzeStates.Add(silverstate)

        private BankOfBITContext db = new BankOfBITContext();

        //
        // GET: /BronzeState/
        // Modified the following code to return the GetInstance() method

        public ActionResult Index()
        {
            return View(BronzeState.GetInstance());
        }

        //
        // GET: /BronzeState/Details/5

        public ActionResult Details(int id = 0)
        {
            //Casted AccountStates to BronzeState
            BronzeState bronzestate = (BronzeState)db.AccountStates.Find(id);
            if (bronzestate == null)
            {
                return HttpNotFound();
            }
            return View(bronzestate);
        }

        //
        // GET: /BronzeState/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BronzeState/Create

        [HttpPost]
        public ActionResult Create(BronzeState bronzestate)
        {
            if (ModelState.IsValid)
            {
                db.BronzeStates.Add(bronzestate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bronzestate);
        }

        //
        // GET: /BronzeState/Edit/5

        public ActionResult Edit(int id = 0)
        {
            //Casted AccountStates to BronzeState
            BronzeState bronzestate = (BronzeState)db.AccountStates.Find(id);
            if (bronzestate == null)
            {
                return HttpNotFound();
            }
            return View(bronzestate);
        }

        //
        // POST: /BronzeState/Edit/5

        [HttpPost]
        public ActionResult Edit(BronzeState bronzestate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bronzestate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bronzestate);
        }

        //
        // GET: /BronzeState/Delete/5

        public ActionResult Delete(int id = 0)
        {
            //Casted AccountStates to BronzeState
            BronzeState bronzestate = (BronzeState)db.AccountStates.Find(id);
            if (bronzestate == null)
            {
                return HttpNotFound();
            }
            return View(bronzestate);
        }

        //
        // POST: /BronzeState/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //Casted AccountStates to BronzeState
            BronzeState bronzestate = (BronzeState)db.AccountStates.Find(id);
            db.AccountStates.Remove(bronzestate);
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