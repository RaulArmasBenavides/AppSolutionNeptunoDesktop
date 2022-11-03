using Neptuno.Libreria.DataAccess;
using Neptuno.Libreria.Entity;
using Neptuno.Libreria.SqlServer;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Neptuno.Libreria.Business
{
    public class CategoriaBLL : AccesoDB
    {
        #region Metodos de Negocio
        public List<CategoriaTO> categoriaListar()
        {
            List<CategoriaTO> listar = null;
            using (var cn = new SqlConnection(CadenaConexion))
            {
                CategoriaDAO dao;
                try
                {
                    dao = new CategoriaDAO();
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
