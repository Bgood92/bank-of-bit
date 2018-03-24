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
    public class NextMortgageAccountController : Controller
    {
        private BankOfBITContext db = new BankOfBITContext();

        //
        // GET: /NextMortgageAccount/
        // Modified the code below to invoke the GetInstance() method

        public ActionResult Index()
        {
            return View(NextMortgageAccount.GetInstance());
        }

        //
        // GET: /NextMortgageAccount/Details/5

        public ActionResult Details(int id = 0)
        {
            NextMortgageAccount nextmortgageaccount = db.NextMortgageAccounts.Find(id);
            if (nextmortgageaccount == null)
            {
                return HttpNotFound();
            }
            return View(nextmortgageaccount);
        }

        //
        // GET: /NextMortgageAccount/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NextMortgageAccount/Create

        [HttpPost]
        public ActionResult Create(NextMortgageAccount nextmortgageaccount)
        {
            if (ModelState.IsValid)
            {
                db.NextMortgageAccounts.Add(nextmortgageaccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextmortgageaccount);
        }

        //
        // GET: /NextMortgageAccount/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NextMortgageAccount nextmortgageaccount = db.NextMortgageAccounts.Find(id);
            if (nextmortgageaccount == null)
            {
                return HttpNotFound();
            }
            return View(nextmortgageaccount);
        }

        //
        // POST: /NextMortgageAccount/Edit/5

        [HttpPost]
        public ActionResult Edit(NextMortgageAccount nextmortgageaccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextmortgageaccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextmortgageaccount);
        }

        //
        // GET: /NextMortgageAccount/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NextMortgageAccount nextmortgageaccount = db.NextMortgageAccounts.Find(id);
            if (nextmortgageaccount == null)
            {
                return HttpNotFound();
            }
            return View(nextmortgageaccount);
        }

        //
        // POST: /NextMortgageAccount/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NextMortgageAccount nextmortgageaccount = db.NextMortgageAccounts.Find(id);
            db.NextMortgageAccounts.Remove(nextmortgageaccount);
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