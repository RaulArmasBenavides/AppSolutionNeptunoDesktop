using System.Configuration;

namespace Neptuno.Libreria.SqlServer
{
    public class AccesoDB
    {
        #region Propiedad
        public string CadenaConexion { get; set; }

        #endregion

        #region Constructor
        public AccesoDB()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["Neptuno"].ConnectionString;
        }
        #endregion

    }
}
