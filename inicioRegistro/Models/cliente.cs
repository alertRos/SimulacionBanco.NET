using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using inicioRegistro.Models;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace inicioRegistro.Models
{
    public partial class Client                
    {
 

            //UTILIZANDO SQLClient
            /*         conexion cx = conexion.obtenerInstancia();
             *         fk_idUsuario = idUser;
             * string query = "INSERT INTO `cliente` (`nombre`, `apellido`, `cedula`, `direccion`, `telefono`,`fk_idUsuario`)" +
                 $" VALUES ('@nombre', '@apellido', '@cedula', '@direccion', '@telefono','@fk_idUsuario');";

             using (cx.getConnection())
             {
                 SqlCommand command = new SqlCommand(query, cx.getConnection());
                 command.Parameters.AddWithValue("@nombre", nombre);
                 command.Parameters.AddWithValue("@apellido", apellido);
                 command.Parameters.AddWithValue("@cedula", cedula);
                 command.Parameters.AddWithValue("@direccion", direccion);
                 command.Parameters.AddWithValue("@telefono", telefono);
                 command.Parameters.AddWithValue("@fk_idUsuario", fk_idUsuario);


                 cx.getConnection().Open();
                 command.ExecuteNonQuery();
                 cx.getConnection().Close();*/
       /* }
            //
            //return getIdCliente();
            return idCliente;
        }

        public void Crear()
        {
            using (cx.getConnection())
            {
                string query = "INSERT INTO `cliente` (`nombre`, `apellido`, `cedula`, `direccion`, `telefono`,`fk_idUsuario`)" +
                 $" VALUES ('@nombre', '@apellido', '@cedula', '@direccion', '@telefono','@fk_idUsuario');";

                SqlCommand command = new SqlCommand(query, cx.getConnection());
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@cedula", cedula);
                command.Parameters.AddWithValue("@direccion", direccion);
                command.Parameters.AddWithValue("@telefono", telefono);
                command.Parameters.AddWithValue("@fk_idUsuario", fk_idUsuario);

                cx.getConnection().Open();
                command.ExecuteNonQuery();
                cx.getConnection().Close();
            }

        }/*
        public int obteneridCliente_usuario(int idUsuario)
        {
            cx.conectar();
            string script = $"SELECT idCliente from cliente where fk_idUsuario ='{idUsuario}';";

            MySqlDataReader reader = cx.getComando(script).ExecuteReader();
            while (reader.Read())
            {
                idCliente = reader.GetFieldValue<int?>("FavoriteNumber");
            }
            cx.desconectar();
            return idCliente;
        }
        public int getIdCliente()
        {
            string script2 = $"select idCliente from cliente where cedula='{cedula}';";
            cx.conectar();
            MySqlDataReader reader = cx.getComando(script2).ExecuteReader();
            while (reader.Read())
            {
                idCliente = reader.GetInt32("idCliente");
            }
            cx.desconectar();

            return idCliente;
        }*/

    }
}