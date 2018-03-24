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
    public class AccountStateController : Controller
    {
        private BankOfBITContext db = new BankOfBITContext();

        //
        // GET: /AccountState/

        public ActionResult Index()
        {
            return View(db.AccountStates.ToList());
        }

        //
        // GET: /AccountState/Details/5

        public ActionResult Details(int id = 0)
        {
            AccountState accountstate = db.AccountStates.Find(id);
            if (accountstate == null)
            {
                return HttpNotFound();
            }
            return View(accountstate);
        }

        //
        // GET: /AccountState/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AccountState/Create

        [HttpPost]
        public ActionResult Create(AccountState accountstate)
        {
            if (ModelState.IsValid)
            {
                db.AccountStates.Add(accountstate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accountstate);
        }

        //
        // GET: /AccountState/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AccountState accountstate = db.AccountStates.Find(id);
            if (accountstate == null)
            {
                return HttpNotFound();
            }
            return View(accountstate);
        }

        //
        // POST: /AccountState/Edit/5

        [HttpPost]
        public ActionResult Edit(AccountState accountstate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountstate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accountstate);
        }

        //
        // GET: /AccountState/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AccountState accountstate = db.AccountStates.Find(id);
            if (accountstate == null)
            {
                return HttpNotFound();
            }
            return View(accountstate);
        }

        //
        // POST: /AccountState/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountState accountstate = db.AccountStates.Find(id);
            db.AccountStates.Remove(accountstate);
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