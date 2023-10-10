using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace inicioRegistro.Models
{
    public partial class Loan
    {
        public double generarCosto(int cuotas, double interes)
        {
            double operacion1 = (interes / 100) * capital;
            double _op2 = (1 / (1 + (interes / 100)));
            double operacion2 = 1 - Math.Pow(_op2, cuotas);

            return operacion1 / operacion2;
        }

      /*  public double getCosto(int id)
        {
            string script = $"SELECT costoPrestamo FROM prestamos WHERE fk_idFiador ='{id}';";

            cx.conectar();
            MySqlDataReader reader = cx.getComando(script).ExecuteReader();
            while (reader.Read())
            {
                costoPrestamo = reader.GetDouble("costoPrestamo");
            }
            cx.desconectar();

            return costoPrestamo;
        }*/

        /*      private string getnCuenta()
              {
                  cx.conectar();
                  string script = $"SELECT numCuenta FROM cuenta WHERE fk_idCliente ={fk_idFiador};";

                  MySqlDataReader reader = cx.getComando(script).ExecuteReader();
                  while (reader.Read())
                  {
                      numCuenta = reader.GetString("numCuenta");
                  }
                  cx.desconectar();
                  return numCuenta;
              }

              public void registrarPrestamo()
              {
                  obtenerUsuario();
                  getFechaSolicitud();
                  getMontoSolicitado();

                  string script = $"INSERT INTO `prestamos`(`idPrestamos`, `fk_idFiador`, `Garantia`, `fechaSolicitud`, `fechaAprobacion`, `FechaInicio`, `FechaTermino`,`tasaInteres`,`capital`,`costoPrestamo`)" +
                      $" VALUES (NULL,'{fk_idFiador}','{garantia}','{fechaSolicitud}','{fechaAprobacion}','{fechaInicio}','{fechaTermino}','{tasaInteres}','{capital}','{costoPrestamo}')";

                  cx.conectar();
                  cx.getComando(script).ExecuteNonQuery();
                  actualizarEstadoSolicitud();
                  actualizarSaldo();
                  cx.desconectar();

              }
              public void obtenerUsuario()
              {
                  cx.conectar();
                  string script0 = $"SELECT fk_idCliente FROM solicitud_prestamo WHERE numCuenta ={numCuenta};";

                  MySqlDataReader reader = cx.getComando(script0).ExecuteReader();
                  while (reader.Read())
                  {
                      fk_idFiador = reader.GetInt32("fk_idCliente");
                  }
                  cx.desconectar();
              }

              private string getFechaSolicitud()
              {

                  string script = $"SELECT fechaSolicitud FROM solicitud_prestamo INNER JOIN cliente on solicitud_prestamo.fk_idCliente = cliente.idCliente INNER JOIN cuenta ON cuenta.fk_idCliente = cliente.idCliente WHERE cuenta.numCuenta ='{numCuenta}';";

                  cx.conectar();
                  MySqlDataReader reader = cx.getComando(script).ExecuteReader();
                  while (reader.Read())
                  {
                      fechaSolicitud = reader.GetString("fechaSolicitud");
                  }
                  cx.desconectar();

                  return fechaSolicitud;
              }
              private double getMontoSolicitado()
              {
                  string script = $"SELECT montoSolicitado FROM solicitud_prestamo INNER JOIN cliente on solicitud_prestamo.fk_idCliente = cliente.idCliente INNER JOIN cuenta ON cuenta.fk_idCliente = cliente.idCliente WHERE cuenta.numCuenta ='{numCuenta}';";

                  cx.conectar();
                  MySqlDataReader reader = cx.getComando(script).ExecuteReader();
                  while (reader.Read())
                  {
                      capital = reader.GetDouble("montoSolicitado");
                  }
                  cx.desconectar();

                  return capital;
              }




              private void actualizarEstadoSolicitud()
              {
                  string conStr = "server=127.0.0.1;port=3306;database=db_banco;uid=root;pwd=;";
                  using (MySqlConnection conn = new MySqlConnection(conStr))
                  {
                      if (conn.State == System.Data.ConnectionState.Closed)
                          conn.Open();

                      string script = $"UPDATE solicitud_prestamo SET estadoSolicitud ='Aprobado' WHERE numCuenta = {numCuenta}";

                      MySqlCommand cmd = new MySqlCommand(script, conn);

                      cmd.ExecuteNonQuery();

                      if (conn.State != System.Data.ConnectionState.Closed)
                          conn.Close();
                  }
              }
              private void actualizarSaldo()
              {
                  Transacciones transaccion = new Transacciones();
                  double saldo = transaccion.getSaldoDestino(numCuenta);

                  double d_saldoFinal = saldo + capital;

                  string conStr = "server=127.0.0.1;port=3306;database=db_banco;uid=root;pwd=;";
                  using (MySqlConnection conn = new MySqlConnection(conStr))
                  {
                      if (conn.State == System.Data.ConnectionState.Closed)
                          conn.Open();

                      string script = $"UPDATE cuenta SET saldo = {d_saldoFinal} WHERE numCuenta = {numCuenta}";

                      MySqlCommand cmd = new MySqlCommand(script, conn);

                      cmd.ExecuteNonQuery();

                      if (conn.State != System.Data.ConnectionState.Closed)
                          conn.Close();
                  }
              }

              //CRONOGRAMA


        */

    }

    }

