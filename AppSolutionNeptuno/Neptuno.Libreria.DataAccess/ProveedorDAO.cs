using System.Collections.Generic;
using System.Data.SqlClient;
using Neptuno.Libreria.Entity;
using Neptuno.Libreria.Service;
using System.Data;

namespace Neptuno.Libreria.DataAccess
{
    public class ProveedorDAO : ICrudService<ProveedorTO>
    {
        #region Metodos de Persistencia
        public void create(SqlConnection c, ProveedorTO t)
        {
            
        }

        public void delete(SqlConnection c, ProveedorTO t)
        {
            
        }

        public ProveedorTO findForId(SqlConnection c, object t)
        {
            return null;
        }

        public List<ProveedorTO> readAll(SqlConnection c)
        {
            List<ProveedorTO> proveedores = new List<ProveedorTO>();
            using (var cmd = new SqlCommand("usp_Proveedor_Listar", c))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                var dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    int posId = dr.GetOrdinal("IdProveedor");
                    int posNom = dr.GetOrdinal("NombreCompañía");
                    int posDir = dr.GetOrdinal("Dirección");
                    int posCiu = dr.GetOrdinal("Ciudad");
                    int posPai = dr.GetOrdinal("País");
                    int posTel = dr.GetOrdinal("Teléfono");
                    //int posFax = dr.GetOrdinal("Fax");

                    ProveedorTO pro = null;
                    while (dr.Read())
                    {
                        pro = new ProveedorTO()
                        {
                            IdProveedor = dr.GetInt32(posId),
                            NombreProveedor=dr.GetString(posNom),
                            Direccion= dr.GetString(posDir),
                            Ciudad= dr.GetString(posCiu),
                            Pais= dr.GetString(posPai),
                            Telefono= dr.GetString(posTel),
                            //Fax= dr.GetString(posFax)
                        };
                        proveedores.Add(pro);
                    }
                    dr.Close();
                }
            }
            return proveedores;
        }

        public void update(SqlConnection c, ProveedorTO t)
        {
            
        }

        #endregion
    }
}
