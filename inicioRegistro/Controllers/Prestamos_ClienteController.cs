using System;
using System.Collections.Generic;
using System.Linq;
using inicioRegistro.Models;
using System.Web;
using System.Web.Mvc;
using inicioRegistro.Models.ViewModel;

namespace inicioRegistro.Controllers
{
    public class Prestamos_ClienteController : Controller
    {
        int idUsuario = Global.idUsuario;
        // GET: Prestamos_Cliente

        public ActionResult Index()
        {
            try
            {
                List<PrestamosViewData> lst = null;

                using (DBModel db = new DBModel())
                {
                    var cliente = db.Clients.Where(x => x.fk_idUsuario == idUsuario).FirstOrDefault();

                    lst = (from d in db.LoanApplications
                           where d.fk_idCliente == cliente.idCliente

                           select new PrestamosViewData
                           {
                               id = d.idSolicitud,
                               monto = d.montoSolicitado,
                               estado = d.estadoSolicitud

                           }).ToList();

                    return View("prestamosQuery", lst);
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("error");
            }
        }
        public ActionResult cancelarSolicitud(int id)
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    var solicitud = db.LoanApplications.Where(x => x.idSolicitud == id).FirstOrDefault();
                    db.LoanApplications.Remove(solicitud);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }catch (Exception e)
            {
                return RedirectToAction("error");
            }
        }

        public ActionResult error()
        {
            return View();
        }

        public ActionResult formSolicitud()
        {
            return View();
        }

        public ActionResult finalizarSolicitud()
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    var solicitud_Prestamo = new LoanApplication()
                    {
                        montoSolicitado = Convert.ToDouble(Request.Form["monto"]),
                        fechaSolicitud = DateTime.UtcNow.ToString("MM-dd-yyyy"),
                        estadoSolicitud = "SIN APROBAR"
                    };

                    var oClient = db.Clients.Where(x => x.fk_idUsuario == idUsuario).First();
                    var oAccount = db.Accounts.Where(x => x.fk_idCliente == oClient.idCliente).First();

                    solicitud_Prestamo.fk_idCliente = oClient.idCliente;

                    solicitud_Prestamo.numCuenta = oAccount.numCuenta;

                    db.LoanApplications.Add(solicitud_Prestamo);
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

        public ActionResult realizarPago()
        {
            return View();
        }

        public ActionResult prestamosQuery()
        {
            return View();
        }

        public ActionResult CronogramaPagos()
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    //buscando el idCliente a través del idUsuario
                    var cliente = db.Clients.Where(x => x.fk_idUsuario == idUsuario).FirstOrDefault();
                    int idCliente = cliente.idCliente;

                    var prestamo = db.Loans.Where(x => x.fk_idCliente == idCliente).FirstOrDefault();

                    var pagoPrestamo = new LoanSchedule()
                    {
                        fk_idCliente = idCliente,
                        fk_idPrestamo = prestamo.idPrestamo,
                        cuotaPrestamo = prestamo.costoPrestamo,
                        tipoPago = Request.Form["tipoPago"],
                        abonoCapital = prestamo.capital,
                        fechaPlanificada = prestamo.FechaInicio,
                        fechaEfectiva = prestamo.FechaTermino
                    };

                    var comprobante = db.Payments.Where(x => x.tipoPago == pagoPrestamo.tipoPago).FirstOrDefault();
                    pagoPrestamo.fk_idComprobante = comprobante.idComprobante;

                    db.LoanSchedules.Add(pagoPrestamo);
                    db.SaveChanges();

                    Global.costoPrestamo = prestamo.costoPrestamo;

                    var pago = pagoPrestamo.tipoPago;

                    if (pago == "Transferencia directa")
                    {
                        return RedirectToAction("Prestamos_Cliente", "Transaccion");
                    }
                    else if (pago == "Cheque")
                    {
                    }
                    else if (pago == "Depósito")
                    {
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

        public ActionResult Transaccion()
        {

            return View();
        }

        public ActionResult CompletarTransaccion()
        {
            try
            {
                Transaction transaccion = new Transaction();
                Loan prestamo = new Loan();
                transaccion.transaccion_prestamo(idUsuario);
                return View();
            }catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }
    }
}