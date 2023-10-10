﻿using System;
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
    public class CrudUsersController : Controller
    {
        private DBModel db = new DBModel();

        // GET: CrudUsers
        public ActionResult Index()
        {
            try
            {
                return View(db.Users.ToList());
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudUsers/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CrudUsers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,cUsuario,pin")] User user)
        {
           try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // POST: CrudUsers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,cUsuario,pin")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // POST: CrudUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception e)
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
