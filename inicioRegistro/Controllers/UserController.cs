using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using inicioRegistro.Models;
using System.Web.Mvc;

namespace inicioRegistro.Controllers
{
    public static class Global
    {
        public static int idUsuario;
        public static double costoPrestamo;
        public static double saldo;
        public static string nCuenta;
    }

    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Registro()
        {
            using (DBModel db = new DBModel())
            {
                return View(db.Clients.ToList());
            }
        }
        public ActionResult CrearUsuario()
        {
            try
            {
                var oClient = new Client()
                {
                    fk_idUsuario = 1,
                    nombre = Request.Form["nombre"],
                    apellido = Request.Form["apellido"],
                    cedula = Request.Form["cedula"],
                    direccion = Request.Form["direccion"],
                    telefono = Request.Form["telefono"]
                };

                using(DBModel db = new DBModel())
                {
                    var cliente = db.Clients.Where(x => x.cedula == oClient.cedula).FirstOrDefault();

                    if (cliente == null)
                    {
                        return RedirectToAction("FinalizarRegistro", oClient);
                    }
                    else
                    {
                        ViewBag.mensaje = "Cedula ya registrada";
                        return View("Registro");
                    }
                }

                
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        public ActionResult FinalizarRegistro(Client oClient)
        {
            try
            {
                Account datoCuenta = new Account();
                Global.nCuenta = datoCuenta.generarNumCuenta();
                ViewBag.nCuenta = Global.nCuenta;
                ViewBag.nombre = oClient.nombre;
                ViewBag.cedula = oClient.cedula;
                using (DBModel db = new DBModel())
                {
                    db.Clients.Add(oClient);
                    db.SaveChanges();

                    return View();
                }
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        public ActionResult UltimoPaso()
        {
            try
            {
                Account datoCuenta = new Account();
                User datoUsuario = new User();
                Client cliente = new Client();

                using (DBModel db = new DBModel())
                {
                    var cedula = Request.Form["cedula"];
                    Client oClient = db.Clients.Where(x => x.cedula == cedula).First();
                    int idCliente = oClient.idCliente;

                    Account oAccount = new Account()
                    {
                        numCuenta = Global.nCuenta,
                        fk_idCliente = idCliente,
                        saldo = 500.00,
                    };
                    db.Accounts.Add(oAccount);
                    db.SaveChanges();


                    var oUser = new User()
                    {
                        pin = Convert.ToInt32((Request.Form["pin"])),
                        cUsuario = oClient.cedula
                    };

                    db.Users.Add(oUser);
                    db.SaveChanges();

                    oClient.fk_idUsuario = oUser.idUsuario;
                    db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("inicioSesion");
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }
        public ActionResult inicioSesion()
        {
            return View();
        }
        public ActionResult IniciarSesion()
        {
            try
            {
                string cUser = Request.Form["cedula"];
                int pin = Convert.ToInt32(Request.Form["pin"]);
                User usuario = new User();
                var resultado = usuario.UsuarioExiste(cUser);

                if (cUser == "@$,F01'k0=&" && Request.Form["pin"] == "1010")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    if (resultado == null)
                    {
                        ViewBag.mensaje = "Usuario no existe";
                        return View("inicioSesion");
                    }
                    else
                    {
                        if (resultado.pin != pin)
                        {
                            ViewBag.mensaje = "Contraseña incorrecta";
                            return View("inicioSesion");
                        }
                        else if (resultado.pin == pin)
                        {
                            usuario.cUsuario = cUser;
                            using (DBModel db = new DBModel())
                            {
                                var oUser = db.Users.Where(x => x.cUsuario == cUser).FirstOrDefault();
                                usuario.pin = oUser.pin;
                                Global.idUsuario = oUser.idUsuario;
                                return RedirectToAction("Inicio");
                            }
                        }
                    }
                    return View();
                }
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }


        public ActionResult Inicio()
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    Account cuenta = new Account();
                    var oClient = db.Clients.Where(x => x.fk_idUsuario == Global.idUsuario).First();
                    var oAccount = db.Accounts.Where(x => x.fk_idCliente == oClient.idCliente).First();

                    var saldo = oAccount.saldo;
                    ViewBag.saldo = saldo;
                    return View();
                }
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }
    }
}
