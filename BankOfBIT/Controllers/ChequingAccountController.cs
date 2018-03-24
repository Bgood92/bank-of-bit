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
    public class ChequingAccountController : Controller
    {
        //Changed every instance of db.BankAccounts.Find(id) to a ChequingAccount
        //Changed AccountStateId in the third parameter of the Create and Edit methods to "Description"

        private BankOfBITContext db = new BankOfBITContext();

        //
        // GET: /Chequing/

        public ActionResult Index()
        {
            var bankaccounts = db.ChequingAccounts.Include(c => c.Client).Include(c => c.AccountState);
            return View(bankaccounts.ToList());
        }

        //
        // GET: /Chequing/Details/5

        public ActionResult Details(int id = 0)
        {
            ChequingAccount chequingaccount = db.ChequingAccounts.Find(id);
            if (chequingaccount == null)
            {
                return HttpNotFound();
            }
            return View(chequingaccount);
        }

        //
        // GET: /Chequing/Create

        public ActionResult Create()
        {
            //Modified the following parameters to include FullName and NOT FirstName
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName");
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description");
            return View();
        }

        //
        // POST: /Chequing/Create
        //Added chequingaccount.ChangeState() and db.SaveChanges()

        [HttpPost]
        public ActionResult Create(ChequingAccount chequingaccount)
        {
            //Added this line of code to set the next account number
            chequingaccount.SetNextAccountNumber();

            if (ModelState.IsValid)
            {
                db.BankAccounts.Add(chequingaccount);
                db.SaveChanges();
                chequingaccount.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //Modified the following parameters to include FullName and NOT FirstName
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", chequingaccount.ClientId);
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", chequingaccount.AccountStateId);
            return View(chequingaccount);
        }

        //
        // GET: /Chequing/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ChequingAccount chequingaccount = db.ChequingAccounts.Find(id);
            if (chequingaccount == null)
            {
                return HttpNotFound();
            }
            //Modified the following parameters to include FullName and NOT FirstName
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", chequingaccount.ClientId);
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", chequingaccount.AccountStateId);
            return View(chequingaccount);
        }

        //
        // POST: /Chequing/Edit/5
        //Added chequingaccount.ChangeState() and db.SaveChanges()

        [HttpPost]
        public ActionResult Edit(ChequingAccount chequingaccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chequingaccount).State = EntityState.Modified;
                db.SaveChanges();
                chequingaccount.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //Modified the following parameters to include FullName and NOT FirstName
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", chequingaccount.ClientId);
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", chequingaccount.AccountStateId);
            return View(chequingaccount);
        }

        //
        // GET: /Chequing/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ChequingAccount chequingaccount = db.ChequingAccounts.Find(id);
            if (chequingaccount == null)
            {
                return HttpNotFound();
            }
            return View(chequingaccount);
        }

        //
        // POST: /Chequing/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ChequingAccount chequingaccount = db.ChequingAccounts.Find(id);
            db.BankAccounts.Remove(chequingaccount);
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