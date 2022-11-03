using Neptuno.Libreria.DataAccess;
using Neptuno.Libreria.Entity;
using Neptuno.Libreria.SqlServer;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Neptuno.Libreria.Business
{
    public class ProductoBLL : AccesoDB
    {
        #region Metodos de Negocio

        public List<ProductoTO> productoListar()
        {
            List<ProductoTO> listar = null;
            using (var cn=new SqlConnection(CadenaConexion))
            {
                ProductoDAO dao;
                try
                {
                    dao = new ProductoDAO();
                    cn.Open();
                    listar = dao.readAll(cn);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
            return listar;
        }//fin

        public ProductoTO productoBuscar(object id)
        {
            ProductoTO pro = null;
            using (var cn = new SqlConnection(CadenaConexion))
            {
                ProductoDAO dao=null;
                try
                {
                    dao = new ProductoDAO();
                    cn.Open();
                    pro = dao.findForId(cn, id);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
            return pro;
        }//fin

        public string productoProcesar(ProductoTO pro,int opcion)
        {
            string msg = "";
            using (var cn = new SqlConnection(CadenaConexion))
            {
                ProductoDAO dao;
                try
                {
                    dao = new ProductoDAO();
                    cn.Open();
                    switch (opcion)
                    {
                        case 1:
                            dao.create(cn, pro);
                            msg = "Producto registrado con exito";
                            break;
                        case 2:
                            dao.update(cn, pro);
                            msg = "Producto actualizado con exito";
                            break;
                        case 3:
                            dao.delete(cn, pro);
                            msg = "Producto eliminado con exito";
                            break;
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
            return msg;
        }

        #endregion
    }
}
