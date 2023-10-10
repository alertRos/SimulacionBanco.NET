using System;
using System.Collections.Generic;
using System.Linq;
using inicioRegistro.Models;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace inicioRegistro.Controllers
{

    public class TransaccionesController : Controller
    {
        int idUsuario = Global.idUsuario;
        public ActionResult Index()
        {
            return RedirectToAction("Transaccion");
        }

        public ActionResult transaccion_admi()
        {
            return View();
        }

        public ActionResult Transaccion()
        {
            try
            {
                User user = new User();

                using (DBModel db = new DBModel())
                {
                    var oClient = db.Clients.Where(x => x.fk_idUsuario == Global.idUsuario).First();
                    var oAccount = db.Accounts.Where(x => x.fk_idCliente == oClient.idCliente).First();

                    var saldo = oAccount.saldo;
                    ViewBag.saldo = saldo;
                    ViewBag.cuenta = oAccount.numCuenta;
                    return View();
                }
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        public ActionResult CompletarTransaccion()
        {
            try
            {
                User user = new User();
                Account cuenta = new Account();
                using (DBModel db = new DBModel())
                {
                    //Buscando el idCliente a traves del idUsuario
                    var emisor_cliente = db.Clients.Where(x => x.fk_idUsuario == idUsuario).First();
                    var emisor_cuenta = db.Accounts.Where(x => x.fk_idCliente == emisor_cliente.idCliente).First();

                    var _transaccion = new Transaction()
                    {
                        monto = Convert.ToDouble(Request.Form["monto"]),
                        idEmisor = emisor_cliente.idCliente,
                        destinatario = Request.Form["destinatario"],
                        emisor = emisor_cuenta.numCuenta,
                        fechaTransaccion = DateTime.UtcNow.ToString("MM-dd-yyyy"),
                    };

                    //saldo del emisor
                    double e_saldo = emisor_cuenta.saldo;

                    var respuesta = _transaccion.Transaccion(e_saldo);

                    if (_transaccion.destinatario == _transaccion.emisor)
                    {
                        User userM = new User();
                        respuesta = false;
                        string mensaje = "No puede enviar dinero a su propia cuenta, la operación ha sido cancelada";
                        userM.mensaje = mensaje;

                        return RedirectToAction("Transaccion", user);
                    }

                    if (respuesta == true)
                    {
                        db.Transactions.Add(_transaccion);
                        db.SaveChanges();
                        return View();
                    }
                    else
                    {
                        string mensaje = "La operación ha sido cancelada";
                        user.mensaje = mensaje;

                        return RedirectToAction("Transaccion", user);
                    }
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