using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRUEBA.Models
{
    public class Inventario
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string Tipo_de_Producto { get; set; }
        public string Es_Activo { get; set; }

    }
}