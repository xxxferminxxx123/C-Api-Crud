using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductosController : ApiController
    {
        [HttpGet] 
        public List<Productos> Get()
        {
            return ProductosData.Listar();
        }


        [HttpPost]
        [Route("api/productos/agregar")]
        public IHttpActionResult Agregar([FromBody] Productos producto)
        {
            if (producto == null)
            {
                return BadRequest("Datos del producto son nulos.");
            }

            bool resultado = ProductosData.RegistrarProductos(producto);

            if (resultado)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest("Error al registrar el producto.");
            }
        }
        [HttpPost]
        [Route("api/productos/eliminar")]  // Asegúrate de que la ruta es la correcta
        public IHttpActionResult Eliminar([FromBody] Productos producto)
        {
            if (producto == null || producto.idProducto <= 0)
            {
                return BadRequest("ID del producto es inválido o nulo.");
            }

            bool resultado = ProductosData.EliminarProductos(producto);

            if (resultado)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest("Error al eliminar el producto.");
            }
        }

        [HttpPost]
        [Route("api/productos/activar")]  
        public IHttpActionResult Activar([FromBody] Productos producto)
        {
            if (producto == null || producto.idProducto <= 0)
            {
                return BadRequest("ID del producto es inválido o nulo.");
            }

            bool resultado = ProductosData.ActivarProductos(producto);

            if (resultado)
            {
                return Ok(true);
            }
            else
            {
                return BadRequest("Error al eliminar el producto.");
            }
        }


    }

}