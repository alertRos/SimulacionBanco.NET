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
    public class CrudLoansController : Controller
    {
        private DBModel db = new DBModel();

        // GET: CrudLoans
        public ActionResult Index()
        {

            try
            {
                return View(db.Loans.ToList());
            }catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudLoans/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Loan loan = db.Loans.Find(id);
                if (loan == null)
                {
                    return HttpNotFound();
                }
                return View(loan);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudLoans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CrudLoans/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPrestamo,Garantia,idSolicitud,fk_idCliente,fechaAprobacion,FechaInicio,FechaTermino,tasaInteres,capital,costoPrestamo")] Loan loan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Loans.Add(loan);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(loan);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudLoans/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Loan loan = db.Loans.Find(id);
                if (loan == null)
                {
                    return HttpNotFound();
                }
                return View(loan);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // POST: CrudLoans/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPrestamo,Garantia,idSolicitud,fk_idCliente,fechaAprobacion,FechaInicio,FechaTermino,tasaInteres,capital,costoPrestamo")] Loan loan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(loan).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(loan);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudLoans/Delete/5
        public ActionResult Delete(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Loan loan = db.Loans.Find(id);
                if (loan == null)
                {
                    return HttpNotFound();
                }
                return View(loan);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // POST: CrudLoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            try
            {
                Loan loan = db.Loans.Find(id);
                db.Loans.Remove(loan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
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
