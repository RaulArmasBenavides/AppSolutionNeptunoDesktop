using Neptuno.Libreria.DataAccess;
using Neptuno.Libreria.Entity;
using Neptuno.Libreria.SqlServer;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Neptuno.Libreria.Business
{
    public class ProveedorBLL : AccesoDB
    {
        #region Metodos de Negocio

        public List<ProveedorTO> proveedorListar()
        {
            List<ProveedorTO> listar = null;
            using (var cn = new SqlConnection(CadenaConexion))
            {
                ProveedorDAO dao;
                try
                {
                    dao = new ProveedorDAO();
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

        #endregion
    }
}
