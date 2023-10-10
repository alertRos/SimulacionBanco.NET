using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using inicioRegistro.Models;
using MySql.Data.MySqlClient;

namespace inicioRegistro.Models
{
    public partial class User
    {
        public string mensaje { get; set; }
        public User UsuarioExiste(string cUser)
        {

            using (DBModel db = new DBModel())
            {
                User user = db.Users.Where(x=> x.cUsuario == cUser).FirstOrDefault();
                if(user != null)
                {
                    var usuario = new User()
                    {
                        cUsuario = user.cUsuario,
                        pin = user.pin
                    };
                }
                else
                {
                    user = null;
                }

                return user;
            }

            
        }
        /*
                conexion cx = conexion.obtenerInstancia();
              //  cliente cliente = new cliente();


            /*

                public int getId()
                {

                //    cx.conectar();
                    string script = $"SELECT idUsuario from usuario where cUsuario ='{cUsuario}';";

               /*     MySqlDataReader reader = cx.getComando(script).ExecuteReader();
                    while (reader.Read())
                    {
                        idUsuario = reader.GetInt32("idUsuario");
                    }
                    cx.desconectar();

                    return idUsuario;*/
        //   }

        /*   public usuario UsuarioExiste(string user)
           {        
               cx.conectar();

               string script = $"SELECT cUsuario, pin from usuario where cUsuario ='{user}';";

               usuario usuario = new usuario();
               MySqlDataReader reader = cx.getComando(script).ExecuteReader();

               if (reader.HasRows)
               {
                   while (reader.Read())
                   {
                       usuario.cUsuario = reader.GetString("cUsuario");
                       usuario.pin = reader.GetInt32("pin");
                   }
               }
               else
               {
                   usuario = null;
               }

               cx.desconectar();

               return usuario;
           }
           public string getcUsuario(int idCliente)
           {   
               string script = $"select cedula from `cliente` where idCliente='{idCliente}';";
               cx.conectar();

               MySqlDataReader reader = cx.getComando(script).ExecuteReader();
               while (reader.Read())
               {
                   this.cUsuario = reader.GetString("cedula");
               }
               cx.desconectar();
               return cUsuario;
           }
           */
    }
}