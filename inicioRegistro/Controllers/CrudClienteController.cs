using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using inicioRegistro.Models;

namespace inicioRegistro.Controllers
{
    public class CrudClienteController : Controller
    {
        // GET: CrudCliente
        public ActionResult Index()
        {

            try
            {
                using(DBModel context = new DBModel())
                {
                    return View(context.Clients.ToList());
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudCliente/Details/5
        public ActionResult Details(int id)
        {

            try
            {
                using (DBModel context = new DBModel())
                {
                    return View(context.Clients.Where(x => x.idCliente == id));
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // GET: CrudCliente/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CrudCliente/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {
                using (DBModel context = new DBModel())
                {
                    context.Clients.Add(client);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CrudCliente/Edit/5
        public ActionResult Edit(int id)
        {

            try
            {
                using (DBModel context = new DBModel())
                {
                    return View(context.Clients.Where(x => x.idCliente == id).FirstOrDefault());
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // POST: CrudCliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Client client)
        {
            try
            {
                using(DBModel context = new DBModel())
                {
                    context.Entry(client).State = EntityState.Modified;
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CrudCliente/Delete/5
        public ActionResult Delete(int id)
        {

            try
            {
                using (DBModel context = new DBModel())
                {
                    return View(context.Clients.Where(x => x.idCliente == id).FirstOrDefault());
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        // POST: CrudCliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
               using(DBModel context = new DBModel())
                {
                    Client client = context.Clients.Where(x => x.idCliente == id).FirstOrDefault();
                    context.Clients.Remove(client);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
