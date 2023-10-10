using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Web;

namespace inicioRegistro.Models
{
    public partial class Account
    {
        private const string numCuenta_primerosCuatro = "0387";
        public string generarNumCuenta()
        {
            Random rnd = new Random();
            int temp2 = rnd.Next(1000, 9000);
            int temp3 = rnd.Next(1000, 9000);
            int temp4 = rnd.Next(1000, 9000);

            string patron2 = Convert.ToString(temp2);
            string patron3 = Convert.ToString(temp3);
            string patron4 = Convert.ToString(temp4);

            numCuenta = $"{numCuenta_primerosCuatro}{patron2}{patron3}{patron4}";

            return numCuenta;
        }

        /* 

         public double getSaldoCuenta2(string n_cuenta)
         {
             cx.conectar();
             string script = $"SELECT saldo FROM cuenta WHERE numCuenta ='{n_cuenta}'";

             MySqlDataReader reader = cx.getComando(script).ExecuteReader();
             while (reader.Read())
             {
                 saldo = Convert.ToDouble(reader.GetString("saldo"));
             }

             cx.desconectar();
             return saldo;
         }



         public int getIdCuenta()
         {
             usuario user = new usuario();
             cx.conectar();
             cuenta cuenta = new cuenta();
             string script = $"SELECT idCuenta FROM cuenta inner join cliente on cuenta.fk_idCliente = cliente.idCliente inner join usuario on usuario.idUsuario = cliente.fk_idUsuario where usuario.idUsuario ={user.getId()};";

             MySqlDataReader reader = cx.getComando(script).ExecuteReader();
             while (reader.Read())
             {
                 idCuenta = reader.GetInt32("idCuenta");
             }

             cx.desconectar();
             return idCuenta;
         }

         public string getNumCuentaRegistro()
         {
             cx.conectar();
             string script = $"SELECT numCuenta from cuenta where saldo='500.00';";

             MySqlDataReader reader = cx.getComando(script).ExecuteReader();
             while (reader.Read())
             {
                 numCuenta = reader.GetString("numCuenta");
             }
             cx.desconectar();

             return numCuenta;
         }
         public string getNumCuenta(int idCliente)
         {
             cx.conectar();
             string script = $"SELECT numCuenta from cuenta where fk_idCliente='{idCliente}';";

             MySqlDataReader reader = cx.getComando(script).ExecuteReader();
             while (reader.Read())
             {
                 numCuenta = reader.GetString("numCuenta");
             }
             cx.desconectar();

             return numCuenta;
         }
         */
    }
}