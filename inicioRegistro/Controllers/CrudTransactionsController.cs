using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using inicioRegistro.Models;

namespace inicioRegistro.Controllers
{
    public class CrudTransactionsController : Controller
    {
        private DBModel db = new DBModel();

        // GET: CrudTransactions
        public ActionResult Index()
        {
            try
            {
                return View(db.Transactions.ToList());
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudTransactions/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Transaction transaction = db.Transactions.Find(id);
                if (transaction == null)
                {
                    return HttpNotFound();
                }
                return View(transaction);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudTransactions/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTransaccion,monto,idEmisor,emisor,destinatario,fechaTransaccion")] Transaction transaction)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Transactions.Add(transaction);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(transaction);

            }catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudTransactions/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Transaction transaction = db.Transactions.Find(id);
                if (transaction == null)
                {
                    return HttpNotFound();
                }
                return View(transaction);

            }catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTransaccion,monto,idEmisor,emisor,destinatario,fechaTransaccion")] Transaction transaction)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(transaction).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(transaction);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudTransactions/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Transaction transaction = db.Transactions.Find(id);
                if (transaction == null)
                {
                    return HttpNotFound();
                }
                return View(transaction);

            }catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // POST: CrudTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Transaction transaction = db.Transactions.Find(id);
                db.Transactions.Remove(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
           
            }catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
