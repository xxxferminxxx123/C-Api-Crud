using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebApi.Models;

namespace WebApi.Data
{
    public class ProductosData
    {

        public static bool RegistrarProductos(Productos oProducto)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrarProductos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", oProducto.nombre);
                cmd.Parameters.AddWithValue("@descripcion", oProducto.descripcion);
                cmd.Parameters.AddWithValue("@precio", oProducto.precio);
                cmd.Parameters.AddWithValue("@categoriaId", oProducto.categoriaId);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool EliminarProductos(Productos oProducto)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("eliminarProductos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", oProducto.idProducto);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool ActivarProductos(Productos oProducto)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("activarProductos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", oProducto.idProducto);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Productos> Listar()
        {
            List<Productos> oListaProductosData= new List<Productos>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaProductosData.Add(new Productos()
                            {
                                idProducto = Convert.ToInt32(dr["idProducto"]),
                                nombre = dr["nombre"].ToString(),
                                descripcion = dr["descripcion"].ToString(),
                                precio = Convert.ToDouble(dr["precio"]),
                                categoriaId = Convert.ToInt32(dr["categoriaId"]),
                            }) ;
                        }

                    }



                    return oListaProductosData;
                }
                catch (Exception ex)
                {
                    return oListaProductosData;
                }
            }
        }

    }
}