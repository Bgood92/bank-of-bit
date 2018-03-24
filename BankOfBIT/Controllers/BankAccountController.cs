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
    public class BankAccountController : Controller
    {
        private BankOfBITContext db = new BankOfBITContext();

        //
        // GET: /BankAccount/

        public ActionResult Index()
        {
            var bankaccounts = db.BankAccounts.Include(b => b.Client).Include(b => b.AccountState);
            return View(bankaccounts.ToList());
        }

        //
        // GET: /BankAccount/Details/5

        public ActionResult Details(int id = 0)
        {
            BankAccount bankaccount = db.BankAccounts.Find(id);
            if (bankaccount == null)
            {
                return HttpNotFound();
            }
            return View(bankaccount);
        }

        //
        // GET: /BankAccount/Create

        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName");
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "AccountStateId");
            return View();
        }

        //
        // POST: /BankAccount/Create

        [HttpPost]
        public ActionResult Create(BankAccount bankaccount)
        {
            if (ModelState.IsValid)
            {
                db.BankAccounts.Add(bankaccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", bankaccount.ClientId);
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "AccountStateId", bankaccount.AccountStateId);
            return View(bankaccount);
        }

        //
        // GET: /BankAccount/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BankAccount bankaccount = db.BankAccounts.Find(id);
            if (bankaccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", bankaccount.ClientId);
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "AccountStateId", bankaccount.AccountStateId);
            return View(bankaccount);
        }

        //
        // POST: /BankAccount/Edit/5

        [HttpPost]
        public ActionResult Edit(BankAccount bankaccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankaccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", bankaccount.ClientId);
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "AccountStateId", bankaccount.AccountStateId);
            return View(bankaccount);
        }

        //
        // GET: /BankAccount/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BankAccount bankaccount = db.BankAccounts.Find(id);
            if (bankaccount == null)
            {
                return HttpNotFound();
            }
            return View(bankaccount);
        }

        //
        // POST: /BankAccount/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BankAccount bankaccount = db.BankAccounts.Find(id);
            db.BankAccounts.Remove(bankaccount);
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