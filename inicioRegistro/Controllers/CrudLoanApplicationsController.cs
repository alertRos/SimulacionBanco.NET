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
    public class CrudLoanApplicationsController : Controller
    {
        private DBModel db = new DBModel();

        // GET: CrudLoanApplications
        public ActionResult Index()
        {
            
            try
            {
                return View(db.LoanApplications.ToList());
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudLoanApplications/Details/5
        public ActionResult Details(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                LoanApplication loanApplication = db.LoanApplications.Find(id);
                if (loanApplication == null)
                {
                    return HttpNotFound();
                }
                return View(loanApplication);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudLoanApplications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CrudLoanApplications/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSolicitud,montoSolicitado,fechaSolicitud,estadoSolicitud,fk_idCliente,numCuenta")] LoanApplication loanApplication)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.LoanApplications.Add(loanApplication);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(loanApplication);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudLoanApplications/Edit/5
        public ActionResult Edit(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                LoanApplication loanApplication = db.LoanApplications.Find(id);
                if (loanApplication == null)
                {
                    return HttpNotFound();
                }
                return View(loanApplication);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // POST: CrudLoanApplications/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSolicitud,montoSolicitado,fechaSolicitud,estadoSolicitud,fk_idCliente,numCuenta")] LoanApplication loanApplication)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(loanApplication).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(loanApplication);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudLoanApplications/Delete/5
        public ActionResult Delete(int? id)
        {

            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                LoanApplication loanApplication = db.LoanApplications.Find(id);
                if (loanApplication == null)
                {
                    return HttpNotFound();
                }
                return View(loanApplication);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // POST: CrudLoanApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            try
            {
                LoanApplication loanApplication = db.LoanApplications.Find(id);
                db.LoanApplications.Remove(loanApplication);
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
