using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Neptuno.Libreria.Entity;
using Neptuno.Libreria.Service;
using System;

namespace Neptuno.Libreria.DataAccess
{
    public class ProductoDAO : ICrudService<ProductoTO>
    {
        #region Metodos de Persistencia
      
        public void create(SqlConnection c, ProductoTO t)
        {
            using (var cmd=new SqlCommand("usp_Producto_Adicionar",c))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre",t.NombreProducto);
                cmd.Parameters.AddWithValue("@IdProveedor", t.IdProveedor);
                cmd.Parameters.AddWithValue("@IdCategoria", t.IdCategoria);
                cmd.Parameters.AddWithValue("@Precio", t.Precio);
                cmd.Parameters.AddWithValue("@Stock", t.Stock);
                cmd.Parameters.Add("@IdProducto",SqlDbType.Int).Direction=ParameterDirection.Output;
                //ejecuta el SP
                cmd.ExecuteNonQuery();
                t.IdProducto = (int) cmd.Parameters["@IdProducto"].Value;
            }
        }

        public void delete(SqlConnection c, ProductoTO t)
        {
            using (var cmd = new SqlCommand("usp_Producto_Eliminar", c))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", t.IdProducto);                
                //ejecuta el SP
                cmd.ExecuteNonQuery();               
            }
        }

        public ProductoTO findForId(SqlConnection c, object t)
        {
            ProductoTO pro1 = null;
            using (var cmd = new SqlCommand("usp_Producto_Buscar", c))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdProducto", Convert.ToInt32(t.ToString()));
                var dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    int posId = dr.GetOrdinal("IdProducto");
                    int posNom = dr.GetOrdinal("NombreProducto");
                    int posPro = dr.GetOrdinal("IdProveedor");
                    int posCat = dr.GetOrdinal("IdCategoría");
                    int posPre = dr.GetOrdinal("PrecioUnidad");
                    int posStk = dr.GetOrdinal("Stock");
                    ProductoTO pro = null;
                    if (dr.Read())
                    {
                        pro = new ProductoTO()
                        {
                            IdProducto = dr.GetInt32(posId),
                            NombreProducto = dr.GetString(posNom),
                            IdProveedor = dr.GetInt32(posPro),
                            IdCategoria = dr.GetInt32(posCat),
                            Precio = dr.GetDecimal(posPre),
                            Stock = dr.GetInt16(posStk)
                        };
                        pro1 = pro;
                    }
                    dr.Close();
                }
            }
            return pro1;
        }

        public List<ProductoTO> readAll(SqlConnection c)
        {
            List<ProductoTO> productos = new List<ProductoTO>();
            using (var cmd = new SqlCommand("usp_Producto_Listar", c))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var dr = cmd.ExecuteReader();
                if (dr!=null)
                {
                    int posId = dr.GetOrdinal("IdProducto");
                    int posNom = dr.GetOrdinal("NombreProducto");
                    int posPro = dr.GetOrdinal("IdProveedor");
                    int posCat = dr.GetOrdinal("IdCategoría");
                    int posPre = dr.GetOrdinal("PrecioUnidad");
                    int posStk = dr.GetOrdinal("UnidadesEnExistencia");
                    ProductoTO pro=null;
                    while (dr.Read())
                    {
                        pro = new ProductoTO()
                        {
                            IdProducto = dr.GetInt32(posId),
                            NombreProducto=dr.GetString(posNom),
                            IdProveedor=dr.GetInt32(posPro),
                            IdCategoria= dr.GetInt32(posCat),
                            Precio= dr.GetDecimal(posPre),
                            Stock= dr.GetInt16(posStk)
                        };
                        productos.Add(pro);
                    }
                    dr.Close();
                }
            }
            return productos;
        }

        public void update(SqlConnection c, ProductoTO t)
        {
            using (var cmd = new SqlCommand("usp_Producto_Actualizar", c))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", t.NombreProducto);
                cmd.Parameters.AddWithValue("@IdProveedor", t.IdProveedor);
                cmd.Parameters.AddWithValue("@IdCategoria", t.IdCategoria);
                cmd.Parameters.AddWithValue("@Precio", t.Precio);
                cmd.Parameters.AddWithValue("@Stock", t.Stock);
                cmd.Parameters.AddWithValue("@IdProducto",t.IdProducto);
                //ejecuta el SP
                cmd.ExecuteNonQuery();               
            }
        }

        #endregion
    }
}
