namespace Neptuno.Libreria.Entity
{
    public class ProductoTO
    {
        #region Propiedades
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdProveedor { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }
        public short Stock { get; set; }

        #endregion
    }
}
