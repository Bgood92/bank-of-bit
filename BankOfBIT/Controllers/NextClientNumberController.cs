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
    public class NextClientNumberController : Controller
    {
        private BankOfBITContext db = new BankOfBITContext();

        //
        // GET: /NextClientNumber/
        // Modified the code below to invoke the GetInstance() method

        public ActionResult Index()
        {
            return View(NextClientNumber.GetInstance());
        }

        //
        // GET: /NextClientNumber/Details/5

        public ActionResult Details(int id = 0)
        {
            NextClientNumber nextclientnumber = db.NextClientNumbers.Find(id);
            if (nextclientnumber == null)
            {
                return HttpNotFound();
            }
            return View(nextclientnumber);
        }

        //
        // GET: /NextClientNumber/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NextClientNumber/Create

        [HttpPost]
        public ActionResult Create(NextClientNumber nextclientnumber)
        {
            if (ModelState.IsValid)
            {
                db.NextClientNumbers.Add(nextclientnumber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nextclientnumber);
        }

        //
        // GET: /NextClientNumber/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NextClientNumber nextclientnumber = db.NextClientNumbers.Find(id);
            if (nextclientnumber == null)
            {
                return HttpNotFound();
            }
            return View(nextclientnumber);
        }

        //
        // POST: /NextClientNumber/Edit/5

        [HttpPost]
        public ActionResult Edit(NextClientNumber nextclientnumber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nextclientnumber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nextclientnumber);
        }

        //
        // GET: /NextClientNumber/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NextClientNumber nextclientnumber = db.NextClientNumbers.Find(id);
            if (nextclientnumber == null)
            {
                return HttpNotFound();
            }
            return View(nextclientnumber);
        }

        //
        // POST: /NextClientNumber/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NextClientNumber nextclientnumber = db.NextClientNumbers.Find(id);
            db.NextClientNumbers.Remove(nextclientnumber);
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