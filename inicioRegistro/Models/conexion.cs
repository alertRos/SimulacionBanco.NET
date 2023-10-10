using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;


namespace inicioRegistro.Models
{
    public sealed class conexion
    {
        private conexion() { }

        MySqlConnection cx;

        private static conexion instancia;

        public static conexion obtenerInstancia()
        {
            if( instancia == null)
            {
                instancia = new conexion();
            }
            return instancia;
        }

        public SqlConnection getConnection()
        {
            string connectionString = "Server=JAVIERBELTRAN\\SQLEXPRESS01;DATAVASE=db_banco;Trusted_Connection= True;TrustServerCertificate=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }

    }
}