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
    public class InvestmentAccountController : Controller
    {
        //Changed every instance of db.BankAccounts.Find(id) to an InvestmentAccount
        //Changed AccountStateId in the third parameter of the Create and Edit methods to "Description"
        //Changed FirstName the parameters of the Create and Edit methods to "FullName"

        private BankOfBITContext db = new BankOfBITContext();

        //
        // GET: /InvestmentAccount/

        public ActionResult Index()
        {
            var bankaccounts = db.InvestmentAccounts.Include(i => i.Client).Include(i => i.AccountState);
            return View(bankaccounts.ToList());
        }

        //
        // GET: /InvestmentAccount/Details/5

        public ActionResult Details(int id = 0)
        {
            InvestmentAccount investmentaccount = db.InvestmentAccounts.Find(id);
            if (investmentaccount == null)
            {
                return HttpNotFound();
            }
            return View(investmentaccount);
        }

        //
        // GET: /InvestmentAccount/Create

        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName");
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description");
            return View();
        }

        //
        // POST: /InvestmentAccount/Create
        //Added investmentaccount.ChangeState() and db.SaveChanges()

        [HttpPost]
        public ActionResult Create(InvestmentAccount investmentaccount)
        {
            //Added this line of code to set the next account number
            investmentaccount.SetNextAccountNumber();

            if (ModelState.IsValid)
            {
                db.BankAccounts.Add(investmentaccount);
                db.SaveChanges();
                investmentaccount.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", investmentaccount.ClientId);
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", investmentaccount.AccountStateId);
            return View(investmentaccount);
        }

        //
        // GET: /InvestmentAccount/Edit/5

        public ActionResult Edit(int id = 0)
        {
            InvestmentAccount investmentaccount = db.InvestmentAccounts.Find(id);
            if (investmentaccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", investmentaccount.ClientId);
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", investmentaccount.AccountStateId);
            return View(investmentaccount);
        }

        //
        // POST: /InvestmentAccount/Edit/5
        //Added investmentaccount.ChangeState() and db.SaveChanges()

        [HttpPost]
        public ActionResult Edit(InvestmentAccount investmentaccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investmentaccount).State = EntityState.Modified;
                db.SaveChanges();
                investmentaccount.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", investmentaccount.ClientId);
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", investmentaccount.AccountStateId);
            return View(investmentaccount);
        }

        //
        // GET: /InvestmentAccount/Delete/5

        public ActionResult Delete(int id = 0)
        {
            InvestmentAccount investmentaccount = db.InvestmentAccounts.Find(id);
            if (investmentaccount == null)
            {
                return HttpNotFound();
            }
            return View(investmentaccount);
        }

        //
        // POST: /InvestmentAccount/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            InvestmentAccount investmentaccount = db.InvestmentAccounts.Find(id);
            db.BankAccounts.Remove(investmentaccount);
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