using System.Collections.Generic;
using System.Data.SqlClient;
using Neptuno.Libreria.Entity;
using Neptuno.Libreria.Service;
using System.Data;

namespace Neptuno.Libreria.DataAccess
{
    public class CategoriaDAO : ICrudService<CategoriaTO>
    {
        #region Metodos de Peristencia
        public void create(SqlConnection c, CategoriaTO t)
        {
            
        }

        public void delete(SqlConnection c, CategoriaTO t)
        {
            
        }

        public CategoriaTO findForId(SqlConnection c, object t)
        {
            return null;
        }

        public List<CategoriaTO> readAll(SqlConnection c)
        {
            List<CategoriaTO> categorias = new List<CategoriaTO>();
            
            using (var cmd = new SqlCommand("usp_Categoria_Listar", c))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    int posId = dr.GetOrdinal("IdCategoría");
                    int posNom = dr.GetOrdinal("NombreCategoría");
                    CategoriaTO cat = null;
                    while (dr.Read())
                    {
                        cat = new CategoriaTO()
                        {
                            IdCategoria = dr.GetInt32(posId),
                            NombreCategoria=dr.GetString(posNom)                           
                        };
                        categorias.Add(cat);
                    }
                    dr.Close();
                }
            }
            return categorias;
        }

        public void update(SqlConnection c, CategoriaTO t)
        {
            
        }

        #endregion
    }
}
