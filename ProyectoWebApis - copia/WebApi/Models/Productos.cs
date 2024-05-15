using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Productos
    {
        public int idProducto {get; set;}
        public string nombre
        {
            get;set;
        }
        public string descripcion
        {
            get;set;
        }
        public double precio
        {
            get;set;
        }
        public int categoriaId
        {
            get;set;
        }
        public DateTime fechaCreacion
        {
            get;set;
        }

    }
}