using System;
using System.Collections.Generic;
using System.Linq;
using inicioRegistro.Models;
using System.Web;
using System.Web.Mvc;
using inicioRegistro.Models.ViewModel;

namespace inicioRegistro.Controllers
{
    public class PrestamosController : Controller
    {
        int idUsuario = Global.idUsuario;
        // GET: Prestamos
        public ActionResult Index()
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.LoanApplications.ToList());
                }
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

        public ActionResult formPrestamos(int id)
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.LoanApplications.ToList());
                }
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }

        }

        public ActionResult finalizarPrestamo()
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    int idSolicitud = Convert.ToInt32(Request.Form["id"]);
                    string nCuenta = Request.Form["nCuenta"];

                    var _garantia = new Garantia()
                    {
                        fk_tipoGarantia = Convert.ToInt32(Request.Form["obtenerGarantia"])
                    };

                    int cuotas = Convert.ToInt32(Request.Form["cuotas"]);
                    double interes = Convert.ToDouble(Request.Form["interes"]);

                    var cuenta = db.Accounts.Where(x => x.numCuenta == nCuenta).FirstOrDefault();
                    var cliente = db.Clients.Find(cuenta.fk_idCliente);

                    int idCliente = cliente.idCliente;

                    var solicitud = db.LoanApplications.Find(idSolicitud);

                    var _prestamo = new Loan()
                    {
                        Garantia = Request.Form["garantia"],
                        fk_idCliente = idCliente,
                        idSolicitud = idSolicitud,
                        fechaAprobacion = DateTime.UtcNow.ToString("MM-dd-yyyy"),
                        FechaInicio = DateTime.UtcNow.ToString("MM-dd-yyyy"),
                        FechaTermino = Request.Form["f_termino"],
                        tasaInteres = interes,
                        capital = solicitud.montoSolicitado,
                    };

                    _prestamo.costoPrestamo = _prestamo.generarCosto(cuotas, interes);

                    db.Loans.Add(_prestamo);
                    db.SaveChanges();

                    solicitud.estadoSolicitud = "APROBADO";

                    db.Entry(solicitud).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return View();
                }
            }catch(Exception e)
            {
                //Console.WriteLine(e);
                return RedirectToAction("ErrorException", "Error");
            }
        }

    }
}