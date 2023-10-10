using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace inicioRegistro.Models
{
    public partial class Transaction
    {
        public bool Transaccion(double saldoEmisor)
        {
            bool _esValido = true;

            if (saldoEmisor < monto)
            {
                _esValido = false;
                return _esValido;
            }
            else
            {
                using (DBModel db = new DBModel())
                {
                    var destinatarioA = db.Accounts.Where(x => x.numCuenta == destinatario).First();
                    //saldo del destinatario
                    double d_saldo = destinatarioA.saldo;
                    //saldo final del emisor o el que realiza la transaccion
                    double e_saldoFinal = saldoEmisor - monto;
                    //saldo final del emisor o el que recibe la transaccion
                    double d_saldoFinal = d_saldo + monto;

                    destinatarioA.saldo = d_saldoFinal;
                    db.Entry(destinatarioA).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    var emisor = db.Accounts.Where(x => x.fk_idCliente == idEmisor).First();

                    emisor.saldo = e_saldoFinal;
                    db.Entry(emisor).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }

            return _esValido;
        }

        public void transaccion_prestamo(int idUsuario) 
        {
            using(DBModel db = new DBModel())
            {
                var cliente = db.Clients.Where(x => x.fk_idUsuario == idUsuario).FirstOrDefault();
                int idCliente = cliente.idCliente;

                var cuenta = db.Accounts.Where(x => x.fk_idCliente == idCliente).FirstOrDefault();
                string num_cuenta = cuenta.numCuenta;
                var saldoDestino = cuenta.saldo;

                var prestamo = db.Loans.Where(x => x.fk_idCliente == idCliente).FirstOrDefault();

                double costo = prestamo.costoPrestamo;
                double pagoPrestamo = saldoDestino - costo;

                cuenta.saldo = pagoPrestamo;
                db.Entry(cuenta).State = System.Data.Entity.EntityState.Modified;

            }

        }
    }
}