using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace inicioRegistro.Models
{
    public class Garantia
    {
        public int idGarantia { get; set; }
        public int fk_tipoGarantia { get; set; }
        private string nombreGarantia { get;set; }

        conexion cx = conexion.obtenerInstancia();
      /*  public string obtenerGarantia(int idGarantia)
        {
            this.fk_tipoGarantia = idGarantia;
            string script = $"SELECT _tipoGarantia FROM tipoGarantia WHERE idGarantia ={fk_tipoGarantia};";

            cx.conectar();
            MySqlDataReader reader = cx.getComando(script).ExecuteReader();
            while (reader.Read())
            {
                nombreGarantia = reader.GetString("_tipoGarantia");
            }
            cx.desconectar();
            return nombreGarantia;
        }*/
    }
}