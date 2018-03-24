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
    public class SavingsAccountController : Controller
    {
        //Changed every instance of db.BankAccounts.Find(id) to a SavingsAccount
        //Changed AccountStateId in the third parameter of the Create and Edit methods to "Description"
        //Changed FirstName the parameters of the Create and Edit methods to "FullName"

        private BankOfBITContext db = new BankOfBITContext();

        //
        // GET: /SavingsAccount/

        public ActionResult Index()
        {
            var bankaccounts = db.SavingsAccounts.Include(s => s.Client).Include(s => s.AccountState);
            return View(bankaccounts.ToList());
        }

        //
        // GET: /SavingsAccount/Details/5

        public ActionResult Details(int id = 0)
        {
            SavingsAccount savingsaccount = db.SavingsAccounts.Find(id);
            if (savingsaccount == null)
            {
                return HttpNotFound();
            }
            return View(savingsaccount);
        }

        //
        // GET: /SavingsAccount/Create

        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName");
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description");
            return View();
        }

        //
        // POST: /SavingsAccount/Create
        //Added savingsaccont.ChangeState() and db.SaveChanges()

        [HttpPost]
        public ActionResult Create(SavingsAccount savingsaccount)
        {
            //Added this line of code to set the next account number
            savingsaccount.SetNextAccountNumber();

            if (ModelState.IsValid)
            {
                db.BankAccounts.Add(savingsaccount);
                db.SaveChanges();
                savingsaccount.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", savingsaccount.ClientId);
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", savingsaccount.AccountStateId);
            return View(savingsaccount);
        }

        //
        // GET: /SavingsAccount/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SavingsAccount savingsaccount = db.SavingsAccounts.Find(id);
            if (savingsaccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", savingsaccount.ClientId);
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", savingsaccount.AccountStateId);
            return View(savingsaccount);
        }

        //
        // POST: /SavingsAccount/Edit/5
        //Added savingsaccount.ChangeState() and db.SaveChanges()

        [HttpPost]
        public ActionResult Edit(SavingsAccount savingsaccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(savingsaccount).State = EntityState.Modified;
                db.SaveChanges();
                savingsaccount.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", savingsaccount.ClientId);
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", savingsaccount.AccountStateId);
            return View(savingsaccount);
        }

        //
        // GET: /SavingsAccount/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SavingsAccount savingsaccount = db.SavingsAccounts.Find(id);
            if (savingsaccount == null)
            {
                return HttpNotFound();
            }
            return View(savingsaccount);
        }

        //
        // POST: /SavingsAccount/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SavingsAccount savingsaccount = db.SavingsAccounts.Find(id);
            db.BankAccounts.Remove(savingsaccount);
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