//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace inicioRegistro.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Loan
    {
        public int idPrestamo { get; set; }
        public string Garantia { get; set; }
        public int idSolicitud { get; set; }
        public int fk_idCliente { get; set; }
        public string fechaAprobacion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
        public double tasaInteres { get; set; }
        public double capital { get; set; }
        public double costoPrestamo { get; set; }
    }
}