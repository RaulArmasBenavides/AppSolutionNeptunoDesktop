using System.Collections.Generic;
using System.Data.SqlClient;

namespace Neptuno.Libreria.Service
{
    public interface ICrudService <T>
    {
        #region Firmas
        void create(SqlConnection c, T t);
        void update(SqlConnection c, T t);
        void delete(SqlConnection c, T t);
        T findForId(SqlConnection c, object t);
        List<T> readAll(SqlConnection c);
        #endregion
    }
}
