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
    
    public partial class Transaction
    {
        public int idTransaccion { get; set; }
        public double monto { get; set; }
        public int idEmisor { get; set; }
        public string emisor { get; set; }
        public string destinatario { get; set; }
        public string fechaTransaccion { get; set; }
    }
}